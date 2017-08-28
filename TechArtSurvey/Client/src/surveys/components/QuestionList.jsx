import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { Button } from 'react-bootstrap';

import { NonEditingQuestionWrapper } from './questions/NonEditingQuestionWrapper';
import { EditingQuestionWrapper } from './questions/EditingQuestionWrapper';
import { getLastNumber } from './service';
import Question from '../models/Question';
import { changeType } from './service';

export class QuestionList extends Component {
  constructor(props) {
    super(props);

    let questions = this.props.questions.map(q => ({...q}));

    this.state = {
      questions : questions,
      editingQuestionNumber : -1,
    };

    this.questionsBuffer = this.props.questions.map(q => ({...q}));
    this.lastNumber = getLastNumber(this.state.questions);
  }

  componentWillReceiveProps = (props) => {
    let questions = props.questions.map(q => ({...q}));
    this.questionsBuffer = props.questions.map(q => ({...q}));
    let newQuestions = this.checkIfEditingQuestionTypeChanged(questions, props.newEditingQuestionType);
    if(newQuestions) {
      this.questionsBuffer = newQuestions;
    }
    this.setState({ questions : questions, editingQuestionNumber : props.editingQuestionNumber });
  }

  checkIfEditingQuestionTypeChanged = (oldQuestions, type) => {
    if(!type || type.length === 0) {
      return null;
    }
    let questions = oldQuestions.map(q => ({...q}));
    let index = questions.findIndex(q => q.number == this.state.editingQuestionNumber);
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
    questions.push(new Question(++this.lastNumber));
    this.setState({ editingQuestionNumber : this.lastNumber, questions : questions });
    this.props.handleOnQuestionsArraySave(questions);
    this.props.handleOnEditingQuestionNumberChange(this.lastNumber);
  }

  handleOnDeleteClick = () => {
    let questions = this.state.questions.map(q => ({...q}));
    let index = questions.findIndex(q => q.number == this.state.editingQuestionNumber);
    questions.splice(index, 1);
    this.setState({ editingQuestionNumber : -1, questions : questions });
    this.props.handleOnQuestionsArraySave(questions);
    this.props.handleOnEditingQuestionNumberChange(-1);
  }

  handleOnQuestionSave = (question) => {
    let questions = this.questionsBuffer.map(q => ({...q}));
    let index = questions.findIndex(q => q.number == this.state.editingQuestionNumber);
    questions[index] = question;
    this.setState({ editingQuestionNumber : -1, questions : questions });
    this.props.handleOnQuestionsArraySave(questions);
    this.props.handleOnEditingQuestionNumberChange(-1);
  }

  handleOnEditingQuestionNumberChange = (number) => {
    this.setState({ editingQuestionNumber : number });
    let resetBuffer = this.state.questions.map(q => ({...q}));
    this.questionsBuffer = resetBuffer;
    this.props.handleOnEditingQuestionNumberChange(number);
  }

  render = () => {
    return (
      <div>
        {
          this.questionsBuffer.map((question, index) => {
            if(this.state.editingQuestionNumber != question.number) {
              return <NonEditingQuestionWrapper
                key={index}
                question={question}
                handleOnQuestionSave={this.handleOnQuestionSave}
                handleOnEditingQuestionNumberChange={this.handleOnEditingQuestionNumberChange}
              />;
            }

            return <EditingQuestionWrapper
              key={index}
              question={question}
              handleOnQuestionSave={this.handleOnQuestionSave}
              handleOnEditingQuestionNumberChange={this.handleOnEditingQuestionNumberChange}
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
  handleOnEditingQuestionNumberChange : PropTypes.func.isRequired,
  editingQuestionNumber : PropTypes.number.isRequired,
  newEditingQuestionType: PropTypes.string,
};
