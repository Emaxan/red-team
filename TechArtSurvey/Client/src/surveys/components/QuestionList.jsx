import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { Button } from 'react-bootstrap';
import { DragDropContext } from 'react-dnd';
import HTML5Backend from 'react-dnd-html5-backend';
import update from 'immutability-helper';

import { NonEditingQuestionWrapper } from './questions/NonEditingQuestionWrapper';
import { EditingQuestionWrapper } from './questions/EditingQuestionWrapper';
import { getLastNumber } from './service';
import Question from '../models/Question';
import DraggableQuestion from './DraggableQuestion';
import { changeType } from './service';

class QuestionList extends Component {
  constructor(props) {
    super(props);

    let questions = this.props.questions.map(q => ({...q}));
    let questionsBuffer = this.props.questions.map(q => ({...q}));

    this.state = {
      questions : questions,
      questionsBuffer : questionsBuffer,
      editingQuestionNumber : -1,
    };

    this.lastNumber = getLastNumber(this.state.questions);
    this.errors = {
      questions : this.props.errors,
    };
  }

  componentWillReceiveProps = (props) => {
    let questions = props.questions.map(q => ({...q}));
    let questionsBuffer = props.questions.map(q => ({...q}));

    let newQuestions = this.checkIfEditingQuestionTypeChanged(questions, props.newEditingQuestionType);
    if (newQuestions) {
      questionsBuffer = newQuestions;
    }

    this.setState({ questions : questions, questionsBuffer : questionsBuffer, editingQuestionNumber : props.editingQuestionNumber });
    this.errors.questions = props.errors;
  }

  moveQuestion = (dragIndex, hoverIndex) => {
    const dragQuestion = this.state.questionsBuffer[dragIndex];

    this.setState(update(this.state, {
      questionsBuffer: {
        $splice: [
          [dragIndex, 1],
          [hoverIndex, 0, dragQuestion],
        ],
      },
    }));

    let questionsBuffer = this.state.questionsBuffer.map(q => ({...q}));
    let questions = questionsBuffer.map(q => ({...q}));

    let temp = this.errors.questions[dragIndex];
    this.errors.questions[dragIndex] = this.errors.questions[hoverIndex];
    this.errors.questions[hoverIndex] = temp;

    this.props.handleOnQuestionsArraySave(questions, this.errors);
  }

  checkIfEditingQuestionTypeChanged = (oldQuestions, type) => {
    if (!type || type.length === 0) {
      return null;
    }

    let questions = oldQuestions.map(q => ({...q}));
    let index = questions.findIndex(q => q.number == this.state.editingQuestionNumber);
    let oldQuestion = {...questions[index]};
    let newQuestion = changeType(oldQuestion, type);

    if (!newQuestion) {
      return null;
    }

    questions[index] = newQuestion;

    return questions;
  }

  handleOnAddQuestionBtnClick = () => {
    let questions = this.state.questions.map(q => ({...q}));
    questions.push(new Question(++this.lastNumber));
    this.setState({ editingQuestionNumber : this.lastNumber, questions : questions });
    this.errors.questions.push({
      title : '',
      metaInfo : '',
    });
    this.props.handleOnQuestionsArraySave(questions, this.errors);
    this.props.handleOnEditingQuestionNumberChange(this.lastNumber);
  }

  handleOnDeleteClick = () => {
    let questions = this.state.questions.map(q => ({...q}));
    let index = questions.findIndex(q => q.number == this.state.editingQuestionNumber);
    questions.splice(index, 1);
    this.errors.questions.splice(index, 1);
    this.setState({ editingQuestionNumber : -1, questions : questions });
    this.props.handleOnQuestionsArraySave(questions, this.errors);
    this.props.handleOnEditingQuestionNumberChange(-1);
  }

  handleOnQuestionSave = (question, errors) => {
    let questionsBuffer = this.state.questionsBuffer.map(q => ({...q}));
    let index = questionsBuffer.findIndex(q => q.number == this.state.editingQuestionNumber);
    questionsBuffer[index] = question;
    let questions = questionsBuffer.map(q => ({...q}));
    this.setState({ editingQuestionNumber : -1, questions : questions, questionsBuffer : questionsBuffer });
    this.errors.questions[index] = errors.question;
    this.props.handleOnQuestionsArraySave(questions, this.errors);
    this.props.handleOnEditingQuestionNumberChange(-1);
  }

  handleOnEditingQuestionNumberChange = (number) => {
    let resetBuffer = this.state.questions.map(q => ({...q}));
    this.setState({ editingQuestionNumber : number, questionsBuffer : resetBuffer });
    this.props.handleOnEditingQuestionNumberChange(number);
  }

  render = () => {
    return (
      <div>
        {
          this.state.questionsBuffer.map((question, index) => {
            if(this.state.editingQuestionNumber != question.number) {
              return (
                <DraggableQuestion
                  key={index}
                  id={question.id}
                  index={index}
                  moveQuestion={this.moveQuestion}
                >
                  <NonEditingQuestionWrapper
                    question={question}
                    moveQuestion={this.moveQuestion}
                    handleOnQuestionSave={this.handleOnQuestionSave}
                    handleOnEditingQuestionNumberChange={this.handleOnEditingQuestionNumberChange}
                    errors = {this.errors.questions[index]}
                  />
                </DraggableQuestion>
              );
            }

            return (
              <DraggableQuestion
                key={index}
                id={question.id}
                index={index}
                moveQuestion={this.moveQuestion}
              >
                <EditingQuestionWrapper
                  question={question}
                  moveQuestion={this.moveQuestion}
                  handleOnQuestionSave={this.handleOnQuestionSave}
                  handleOnEditingQuestionNumberChange={this.handleOnEditingQuestionNumberChange}
                  handleOnDeleteClick={this.handleOnDeleteClick}
                  editing
                  errors = {this.errors.questions[index]}
                />
              </DraggableQuestion>
            );
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
  errors : PropTypes.array.isRequired,
};

export default DragDropContext(HTML5Backend)(QuestionList);