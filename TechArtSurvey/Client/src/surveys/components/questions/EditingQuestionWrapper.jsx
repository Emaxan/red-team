import React, { Component } from 'react';
import { Panel, Button, Checkbox, ButtonGroup } from 'react-bootstrap';
import PropTypes from 'prop-types';

import { questionsFactory } from '../questionsFactory';

import './EditingQuestionWrapper.scss';

export class EditingQuestionWrapper extends Component {
  constructor(props) {
    super(props);

    this.state = {
      question : {...this.props.question},
    };
  }

  handleOnQuestionUpdate = (question) => {
    this.setState({ question: {...question} });
  }

  handleOnSaveClick = () => {
    this.props.handleOnQuestionSave({...this.state.question});
  }

  handleOnCancelClick = () => {
    this.props.handleOnEditingQuestionIdChange(-1);
  }

  handleOnRequiredClick = () => {
    let question = this.state.question;
    question.isRequired = !question.isRequired;
    this.setState({ question: {...question} });
  }

  handleOnDeleteClick = () => {
    this.props.handleOnDeleteClick();
  }

  render = () =>
    <Panel className="edit-question">
      <div className="top-actions">
        <Checkbox onClick={this.handleOnRequiredClick} checked={this.state.question.isRequired} className="top-actions__required">
          Required
        </Checkbox>
        <Button onClick={this.handleOnDeleteClick}>
          Delete
        </Button>
      </div>
      {
        questionsFactory[this.props.question.type](
          this.props.question,
          this.handleOnQuestionUpdate,
          true,
        )
      }
      <ButtonGroup className="bottom-actions">
        <Button onClick={this.handleOnSaveClick}>
          Save
        </Button>
        <Button onClick={this.handleOnCancelClick}>
          Cancel
        </Button>
      </ButtonGroup>
    </Panel>
}

EditingQuestionWrapper.propTypes = {
  handleOnQuestionSave : PropTypes.func.isRequired,
  question : PropTypes.object.isRequired,
  handleOnEditingQuestionIdChange : PropTypes.func.isRequired,
  handleOnDeleteClick : PropTypes.func.isRequired,
};
