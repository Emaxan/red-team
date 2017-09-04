import React, { Component } from 'react';
import { Panel, Button, Checkbox, ButtonGroup } from 'react-bootstrap';
import PropTypes from 'prop-types';

import { questionsFactory } from '../questionsFactory';
import Question from '../../models/Question';
import QuestionError from '../../models/QuestionError';
import {
  VARIANTS_ARE_REQUIRED,
} from '../errors';

import './EditingQuestionWrapper.scss';

export class EditingQuestionWrapper extends Component {
  constructor(props) {
    super(props);

    this.state = {
      question : this.props.question.getCopy(),
      errors : this.props.errors.getCopy(),
    };
  }

  componentWillReceiveProps = (props) => {
    let { type } = props.question;
    let question = this.state.question.getCopy();
    question.type = type;
    this.setState({ question });
  }

  handleOnQuestionUpdate = (question, errors) => {
    this.setState({ question: question.getCopy(), errors : errors.getCopy() });
  }

  handleOnSaveClick = () => {
    let question = this.state.question.getCopy();
    let metaInfo = [];
    question.title = question.title.trim();
    question.metaInfo.map(m => {
      if(m && m.trim().length > 0) {
        metaInfo.push(m.trim());
      }
    });
    question.metaInfo = metaInfo;
    let errors = this.state.errors.getCopy();
    if(metaInfo.length === 0) {
      errors.metaInfo = VARIANTS_ARE_REQUIRED;
    } else {
      errors.metaInfo = null;
    }
    const q = question.getCopy();
    this.setState({ question: q, errors : errors.getCopy() });
    this.props.handleOnQuestionSave(q, errors);
  }

  handleOnCancelClick = () => {
    this.props.handleOnEditingQuestionNumberChange(-1);
  }

  handleOnRequiredClick = () => {
    let { question } = this.state;
    question.isRequired = !question.isRequired;
    this.setState({ question: question.getCopy() });
  }

  handleOnDeleteClick = () => {
    this.props.handleOnDeleteClick();
  }

  isQuestionValid = () => {
    // WILL BE CHANGED
    return this.state.errors.title === null;
  }

  render = () =>
    <div>
      <Panel className="edit-question">
        <div className="top-actions">
          <Checkbox onChange={this.handleOnRequiredClick} checked={this.state.question.isRequired} className="top-actions__required">
            Required
          </Checkbox>
          <Button onClick={this.handleOnDeleteClick}>
            Delete
          </Button>
        </div>
        {
          questionsFactory[this.state.question.type](
            this.state.question,
            this.handleOnQuestionUpdate,
            {
              editing : this.props.editing,
              errors : this.state.errors,
            },
          )
        }
        <ButtonGroup className="bottom-actions">
          <Button onClick={this.handleOnSaveClick} disabled={!this.isQuestionValid()}>
            Save
          </Button>
          <Button onClick={this.handleOnCancelClick}>
            Cancel
          </Button>
        </ButtonGroup>
      </Panel>
    </div>;
}

EditingQuestionWrapper.propTypes = {
  handleOnQuestionSave : PropTypes.func.isRequired,
  question : PropTypes.instanceOf(Question).isRequired,
  errors : PropTypes.instanceOf(QuestionError).isRequired,
  handleOnEditingQuestionNumberChange : PropTypes.func.isRequired,
  handleOnDeleteClick : PropTypes.func.isRequired,
  editing : PropTypes.bool.isRequired,
};
