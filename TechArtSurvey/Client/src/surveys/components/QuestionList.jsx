import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { Button } from 'react-bootstrap';

import { NonEditingQuestionWrapper } from './questions/NonEditingQuestionWrapper';
import { EditingQuestionWrapper } from './questions/EditingQuestionWrapper';
import { getLastId } from './service';
import Question from '../models/Question';
import { changeType } from './service';

export class QuestionList extends Component {
  constructor(props) {
    super(props);

    let questions = this.props.questions.map(q => ({...q}));

    this.state = {
      questions : questions,
      editingQuestionId : -1,
    };

    this.questionsBuffer = this.props.questions.map(q => ({...q}));
    this.lastId = getLastId(this.state.questions);
  }

  componentWillReceiveProps = (props) => {
    let questions = props.questions.map(q => ({...q}));
    this.questionsBuffer = props.questions.map(q => ({...q}));
    let newQuestions = this.checkIfEditingQuestionTypeChanged(questions, props.newEditingQuestionType);
    if(newQuestions) {
      this.questionsBuffer = newQuestions;
    }
    this.setState({ questions : questions, editingQuestionId : props.editingQuestionId });
  }

  checkIfEditingQuestionTypeChanged = (oldQuestions, type) => {
    if(!type || type.length === 0) {
      return null;
    }
    let questions = oldQuestions.map(q => ({...q}));
    let index = questions.findIndex(q => q.id == this.state.editingQuestionId);
    let oldQuestion = {...questions[index]};
    let newQuestion = changeType(oldQuestion, type);

    if(!newQuestion) {
      return null;
    }
    questions[index] = newQuestion;

    return questions;
  }

  handleOnAddQuestionBtnClick = () => {
    let questions = this.state.questions.map(q => ({...q}));
    questions.push(new Question(++this.lastId));
    this.setState({ editingQuestionId : this.lastId, questions : questions });
    this.props.handleOnQuestionsArraySave(questions);
    this.props.handleOnEditingQuestionIdChange(this.lastId);
  }

  handleOnDeleteClick = () => {
    let questions = this.state.questions.map(q => ({...q}));
    let index = questions.findIndex(q => q.id == this.state.editingQuestionId);
    questions.splice(index, 1);
    this.setState({ editingQuestionId : -1, questions : questions });
    this.props.handleOnQuestionsArraySave(questions);
    this.props.handleOnEditingQuestionIdChange(-1);
  }

  handleOnQuestionSave = (question) => {
    let questions = this.questionsBuffer.map(q => ({...q}));
    let index = questions.findIndex(q => q.id == this.state.editingQuestionId);
    questions[index] = question;
    this.setState({ editingQuestionId : -1, questions : questions });
    this.props.handleOnQuestionsArraySave(questions);
    this.props.handleOnEditingQuestionIdChange(-1);
  }

  handleOnEditingQuestionIdChange = (id) => {
    this.setState({ editingQuestionId : id });
    let resetBuffer = this.state.questions.map(q => ({...q}));
    this.questionsBuffer = resetBuffer;
    this.props.handleOnEditingQuestionIdChange(id);
  }

  render = () => {
    return (
      <div>
        {
          this.questionsBuffer.map((question, index) => {
            if(this.state.editingQuestionId != question.id) {
              return <NonEditingQuestionWrapper
                key={index}
                question={question}
                handleOnQuestionSave={this.handleOnQuestionSave}
                handleOnEditingQuestionIdChange={this.handleOnEditingQuestionIdChange}
              />;
            }

            return <EditingQuestionWrapper
              key={index}
              question={question}
              handleOnQuestionSave={this.handleOnQuestionSave}
              handleOnEditingQuestionIdChange={this.handleOnEditingQuestionIdChange}
              handleOnDeleteClick={this.handleOnDeleteClick}
              editing
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
  handleOnQuestionsArraySave : PropTypes.func.isRequired,
  handleOnEditingQuestionIdChange : PropTypes.func.isRequired,
  editingQuestionId : PropTypes.number.isRequired,
  newEditingQuestionType: PropTypes.string,
};
