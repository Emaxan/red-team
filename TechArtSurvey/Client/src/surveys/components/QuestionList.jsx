import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { Button } from 'react-bootstrap';

import { NonEditingQuestionWrapper } from './questions/NonEditingQuestionWrapper';
import { EditingQuestionWrapper } from './questions/EditingQuestionWrapper';
import { changeType, getLastId } from './service';
import Question from '../models/Question';

export class QuestionList extends Component {
  constructor(props) {
    super(props);
    this.state = {
      questions: this.props.questions,
      editingQuestionId: -1,
    };
    this.lastId = getLastId(this.state.questions);
  }

  handleOnEditingQuestionChange = (id) => {
    this.setState({ editingQuestionId : id });
  }

  handleOnTypeChange = (type) => {
    if (this.state.editingQuestionId !== -1) {
      var questions = this.state.questions;
      var index = questions.findIndex(q => q.id == this.state.editingQuestionId);

      var oldQuestion = questions[index];
      var newQuestion = changeType(oldQuestion, type);

      if(newQuestion !== null) {
        questions[index] = newQuestion;
        this.setState({ questions : questions});
        this.props.handleOnQuestionsArraySave(questions);
      }
    }
  }

  handleOnAddQuestionBtnClick = () => {
    var questions = this.state.questions;
    const newQuestionNumber = questions.length + 1;
    questions.push(new Question(++this.lastId, newQuestionNumber));
    this.setState({ editingQuestionId : this.lastId, questions : questions});
    this.props.handleOnQuestionsArraySave(questions);
  }

  handleOnDeleteClick = () => {
    var questions = this.state.questions;
    var index = questions.findIndex(q => q.id == this.state.editingQuestionId);
    questions.splice(index, 1);
    this.setState({ questions : questions});
    this.props.handleOnQuestionsArraySave(questions);
  }

  handleOnQuestionSave = (question) => {
    var questions = this.state.questions;
    var index = questions.findIndex(q => q.id == this.state.editingQuestionId);
    questions[index] = question;
    this.setState({ questions : questions});
    this.props.handleOnQuestionsArraySave(questions);
  }

  render = () => {
    return (
      <div>
        {
          this.state.questions.map((question, index) => {
            if(this.state.editingQuestionId != question.id) {
              return <NonEditingQuestionWrapper
                key = {index}
                question = {question}
                handleOnQuestionSave = {this.handleOnQuestionSave}
                handleOnEditingQuestionChange = {this.handleOnEditingQuestionChange}
              />;
            }
            return <EditingQuestionWrapper
              key = {index}
              question = {question}
              handleOnQuestionSave = {this.handleOnQuestionSave}
              handleOnEditingQuestionChange = {this.handleOnEditingQuestionChange}
              handleOnDeleteClick = {this.handleOnDeleteClick}
            />;
          })
        }
        <Button onClick={this.handleOnAddQuestionBtnClick}>Add question</Button>
      </div>
    );
  }
}

QuestionList.propTypes = {
  questions : PropTypes.array.isRequired,
  handleOnQuestionsArraySave: PropTypes.func.isRequired,
};
