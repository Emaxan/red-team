import React, { Component } from 'react';
import { Panel, Col, FormGroup, FormControl, ControlLabel } from 'react-bootstrap';
import PropTypes from 'prop-types';

import {
  validateTitle,
} from '../../../utils/validation/questionValidation';
import Question from '../../models/Question';
import QuestionError from '../../models/QuestionError';

export class FileQuestion extends Component {
  constructor(props) {
    super(props);

    this.state = {
      question : this.props.question.getCopy(),
    };

    this.errors = this.props.errors.getCopy();

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
    const title = event.target.value;
    const question = this.state.question.getCopy();
    question.title = title;
    this.setValidationState('title', validateTitle(title));
    this.props.handleOnQuestionUpdate(question, this.errors);
    this.setState({question});
  }

  handleOnFileChange = () => {
    if(this.props.editing) return;
    let question = this.state.question.getCopy();
    question.metaInfo = [this.fileUpload.files[0].name];
    this.setState({question});
    this.props.handleOnQuestionUpdate(question, this.errors);
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
  errors : PropTypes.instanceOf(QuestionError).isRequired,
  question : PropTypes.instanceOf(Question).isRequired,
  handleOnQuestionUpdate : PropTypes.func,
  editing : PropTypes.bool,
};

FileQuestion.defaultProps = {
  editing : false,
};
