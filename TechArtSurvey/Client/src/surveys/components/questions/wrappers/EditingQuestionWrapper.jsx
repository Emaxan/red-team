import React, { Component } from 'react';
import { Panel, Button, Checkbox, ButtonGroup, Glyphicon } from 'react-bootstrap';
import PropTypes from 'prop-types';

import { questionsFactory } from '../../questionsFactory';
import Question from '../../../models/Question';
import QuestionError from '../../../models/QuestionError';

import './EditingQuestionWrapper.scss';

export class EditingQuestionWrapper extends Component {
  constructor(props) {
    super(props);

    this.state = {
      question : this.props.question.getCopy(),
      errors : this.props.errors.getCopy(),
      overInput : false,
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
    errors.metaInfo = null;
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

  render = () => {
    const element = (
      <div>
        <Panel className="edit-question" onMouseEnter={() => this.setState({ overInput : true })} onMouseLeave={() => this.setState({ overInput : false })}>
          <div className="top-actions">
            <Checkbox onChange={this.handleOnRequiredClick} checked={this.state.question.isRequired} className="top-actions__required">
            Required
            </Checkbox>
            <Glyphicon glyph="trash" role="button" title="Remove question" onClick={this.handleOnDeleteClick} />
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
      </div>
    );

    return element;
  }
}

EditingQuestionWrapper.propTypes = {
  handleOnQuestionSave : PropTypes.func.isRequired,
  question : PropTypes.instanceOf(Question).isRequired,
  errors : PropTypes.instanceOf(QuestionError).isRequired,
  handleOnEditingQuestionNumberChange : PropTypes.func.isRequired,
  handleOnDeleteClick : PropTypes.func.isRequired,
  editing : PropTypes.bool.isRequired,
};
