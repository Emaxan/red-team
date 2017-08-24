import React, { Component } from 'react';
import { Panel, Button, Radio } from 'react-bootstrap';
import PropTypes from 'prop-types';

import { questionsFactory } from '../questionsFactory';

export class EditingQuestionWrapper extends Component {
  constructor(props) {
    super(props);

    this.state = {
      question: this.props.question,
    };
  }

  handleOnQuestionUpdate = (question) => {
    this.setState({question: question});
  }

  handleOnSaveClick = () => {
    this.props.handleOnQuestionSave(this.state.question);
  }

  handleOnCancelClick = () => {
    this.props.handleOnEditingQuestionIdChange(-1);
  }

  handleOnRequiredClick = () => {
    var question = this.state.question;
    question.isRequired = !question.isRequired;
    this.setState({question: question});
  }

  handleOnDeleteClick = () => {
    this.props.handleOnDeleteClick();
  }

  render = () =>
    <Panel>
      <Radio onClick={this.handleOnRequiredClick} checked={this.state.question.isRequired}>
            Required
      </Radio>
      <Button onClick={this.handleOnDeleteClick}>
            Delete
      </Button>
      {
        questionsFactory[this.props.question.type](
          this.props.question,
          this.handleOnQuestionUpdate,
          true,
        )
      }
      <Button onClick={this.handleOnSaveClick}>
        Save
      </Button>
      <Button onClick={this.handleOnCancelClick}>
        Cancel
      </Button>
    </Panel>
}

EditingQuestionWrapper.propTypes = {
  handleOnQuestionSave: PropTypes.func.isRequired,
  question: PropTypes.object.isRequired,
  handleOnEditingQuestionIdChange: PropTypes.func.isRequired,
  handleOnDeleteClick: PropTypes.func.isRequired,
};