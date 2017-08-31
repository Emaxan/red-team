import React, { Component } from 'react';
import { Panel, Col, FormGroup, FormControl } from 'react-bootstrap';
import PropTypes from 'prop-types';

import {
  TITLE_IS_REQUIRED,
} from '../errors';

export class FileQuestion extends Component {
  constructor(props) {
    super(props);

    let { question } = this.props;
    question.metaInfo = this.props.question.metaInfo.map(m => m);

    this.state = {
      question : question,
      errors : {
        question : {...this.props.errors},
      },
    };
  }

  handleOnTitleChange = (event) => {
    let title = event.target.value;
    let question = {...this.state.question};
    question.title = title;
    let errors = {...this.state.errors};
    if(title.trim().length === 0) {
      errors.question.title = TITLE_IS_REQUIRED;
    } else {
      errors.question.title = null;
    }
    this.props.handleOnQuestionUpdate(question, errors);
    this.setState({
      question : { ...this.state.question, title : title },
      errors : {...this.state.errors, question : errors},
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
        <FormGroup>
          <Col sm={10} smOffset={1}>
            {
              this.props.editing ?
                (
                  <FormControl
                    name="title"
                    type="text"
                    value={this.state.question.title}
                    placeholder="Enter question's title"
                    onChange={this.handleOnTitleChange}
                  />
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
  errors: PropTypes.object.isRequired,
  question: PropTypes.object.isRequired,
  handleOnQuestionUpdate: PropTypes.func.isRequired,
  editing : PropTypes.bool,
};

FileQuestion.defaultProps = {
  editing : false,
};
