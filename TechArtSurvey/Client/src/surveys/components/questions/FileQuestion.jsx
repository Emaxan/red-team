import React, { Component } from 'react';
import { Panel, Col, FormGroup, FormControl } from 'react-bootstrap';
import PropTypes from 'prop-types';

import Question from '../../models/Question';
import QuestionError from '../../models/QuestionError';

export class FileQuestion extends Component {
  constructor(props) {
    super(props);

    this.state = {
      question : this.props.question.getCopy(),
    };

    this.errors = this.props.errors.getCopy();
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
