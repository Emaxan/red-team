import React, { Component } from 'react';
import { Panel, Button, Checkbox, ButtonGroup } from 'react-bootstrap';
import PropTypes from 'prop-types';

import { questionsFactory } from '../questionsFactory';
import {
  VARIANTS_ARE_REQUIRED,
} from '../errors';

import './EditingQuestionWrapper.scss';

export class EditingQuestionWrapper extends Component {
  constructor(props) {
    super(props);

    this.state = {
      question : {...this.props.question},
      errors : {
        question : {...this.props.errors},
      },
    };
  }

  componentWillReceiveProps = (props, errors) => {
    let { type } = props.question;
    this.setState({ question : { ...this.state.question, type : type }, errors : {...this.state.errors, question : {...errors}} });
  }

  handleOnQuestionUpdate = (question, errors) => {
    let metaInfo = question.metaInfo.map(m => m);
    question.metaInfo = metaInfo;
    this.setState({ question: {...question}, errors : {...this.state.errors, question : {...errors}} });
  }

  handleOnSaveClick = () => {
    let question = {...this.state.question};
    let metaInfo = [];
    question.title = question.title.trim();
    question.metaInfo.map(m => {
      if(m && m.trim().length > 0) {
        metaInfo.push(m.trim());
      }
    });
    question.metaInfo = metaInfo;
    let errors = {...this.state.errors};
    if(metaInfo.length === 0) {
      errors.question.metaInfo = VARIANTS_ARE_REQUIRED;
    } else {
      errors.question.metaInfo = null;
    }
    this.setState({ question: {...question}, errors : {...this.state.errors, question : errors} });
    this.props.handleOnQuestionSave({...question}, errors);
  }

  handleOnCancelClick = () => {
    this.props.handleOnEditingQuestionNumberChange(-1);
  }

  handleOnRequiredClick = () => {
    let { question } = this.state;
    question.isRequired = !question.isRequired;
    this.setState({ question: {...question} });
  }

  handleOnDeleteClick = () => {
    this.props.handleOnDeleteClick();
  }

  isQuestionValid = () => {
    // WILL BE CHANGED
    return this.state.errors.question.title === null;
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
              errors : this.state.errors.question,
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
  question : PropTypes.object.isRequired,
  errors : PropTypes.object.isRequired,
  handleOnEditingQuestionNumberChange : PropTypes.func.isRequired,
  handleOnDeleteClick : PropTypes.func.isRequired,
  editing : PropTypes.bool.isRequired,
};
