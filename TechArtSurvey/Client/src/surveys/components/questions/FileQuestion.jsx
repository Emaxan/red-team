import React, { Component } from 'react';
import { Panel, Col, FormGroup, FormControl, ControlLabel } from 'react-bootstrap';
import PropTypes from 'prop-types';

import {
  validateTitle,
} from '../../../utils/validation/questionValidation';

export class FileQuestion extends Component {
  constructor(props) {
    super(props);

    let { question } = this.props;
    question.metaInfo = this.props.question.metaInfo.map(m => m);

    this.state = {
      question : question,
    };

    this.errors = { ...this.props.errors };

    this.validationStates = {
      title : null,
    };
  }

  componentWillMount = () => {
    this.setValidationState('title', validateTitle(this.state.question.title));
  }

  setValidationState = (fieldName, validationInfo) => {
    if (validationInfo.isValid) {
      this.errors[fieldName] = null;
      this.validationStates[fieldName] = 'success';
    } else {
      this.errors[fieldName] = validationInfo.errors[0].message;
      this.validationStates[fieldName] = 'error';
    }
  }

  handleOnTitleChange = (event) => {
    let title = event.target.value;
    let question = { ...this.state.question, title };

    this.setValidationState('title', validateTitle(title));
    this.props.handleOnQuestionUpdate(question, this.errors);
    this.setState({
      question : { ...this.state.question, title },
    });
  }

  handleOnFileChange = () => {
    if(this.props.editing) return;
    this.setState({ metaInfo : [this.fileUpload.files[0].name] });
    let question = {...this.state};
    question.metaInfo = [this.fileUpload.files[0].name];
    this.props.handleOnQuestionUpdate(question);
  }

  render = () => {
    return (
      <Panel>
        <FormGroup validationState={this.validationStates.title}>
          <Col sm={10} smOffset={1}>
            {
              this.props.editing ?
                (
                  <div>
                    <ControlLabel>
                      {this.errors.title || 'Title'}
                    </ControlLabel>
                    <FormControl
                      name="title"
                      type="text"
                      placeholder="Enter title"
                      value={this.state.question.title}
                      onChange={this.handleOnTitleChange}
                    />
                  </div>
                ) :
                (
                  this.props.question.title
                )
            }
          </Col>
        </FormGroup>

        <FormGroup>
          <Col sm={8} smOffset={1}>
            <input
              name="option"
              type="file"
              onChange={this.handleOnFileChange}
              ref={(ref) => this.fileUpload = ref}
            />
            <FormControl
              readOnly
              name="option"
              type="text"
              value={this.state.question.metaInfo[0] || ''}
              placeholder="Select file"
            />
          </Col>
        </FormGroup>
      </Panel>
    );
  }
}

FileQuestion.propTypes = {
  errors: PropTypes.shape({
    question : PropTypes.shape({
      title : PropTypes.string.isRequired,
      metaInfo : PropTypes.string.isRequired,
    }),
  }).isRequired,
  question: PropTypes.shape({
    isRequired : PropTypes.bool.isRequired,
    metaInfo : PropTypes.arrayOf(String).isRequired,
    number : PropTypes.number.isRequired,
    title : PropTypes.string.isRequired,
    type : PropTypes.string.isRequired,
  }).isRequired,
  handleOnQuestionUpdate: PropTypes.func.isRequired,
  editing : PropTypes.bool,
};

FileQuestion.defaultProps = {
  editing : false,
};
