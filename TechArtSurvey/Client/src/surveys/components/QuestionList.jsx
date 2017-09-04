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
import QuestionError from '../models/QuestionError';
import DraggableQuestion from './DraggableQuestion';
import { changeType } from './service';

class QuestionList extends Component {
  constructor(props) {
    super(props);

    let questions = this.props.questions.map(q => q.getCopy());
    let questionsBuffer = this.props.questions.map(q => q.getCopy());

    this.state = {
      questions : questions,
      questionsBuffer : questionsBuffer,
      editingQuestionNumber : -1,
    };

    this.lastNumber = getLastNumber(this.state.questions);
    this.errors = this.props.errors;
  }

  componentWillReceiveProps = (props) => {
    let questions = props.questions.map(q => q.getCopy());
    let questionsBuffer = props.questions.map(q => q.getCopy());

    let newQuestions = this.checkIfEditingQuestionTypeChanged(questions, props.newEditingQuestionType);
    if (newQuestions) {
      questionsBuffer = newQuestions;
    }

    this.setState({ questions : questions, questionsBuffer : questionsBuffer, editingQuestionNumber : props.editingQuestionNumber });
    this.errors = props.errors;
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

    let questionsBuffer = this.state.questionsBuffer.map(q => q.getCopy());
    let questions = questionsBuffer.map(q => q.getCopy());

    let temp = this.errors[dragIndex];
    this.errors[dragIndex] = this.errors[hoverIndex];
    this.errors[hoverIndex] = temp;

    this.props.handleOnQuestionsArraySave(questions, this.errors);
  }

  checkIfEditingQuestionTypeChanged = (oldQuestions, type) => {
    if (!type || type.length === 0) {
      return null;
    }

    let questions = oldQuestions.map(q => q.getCopy());
    let index = questions.findIndex(q => q.number == this.state.editingQuestionNumber);
    let oldQuestion = questions[index].getCopy();
    let newQuestion = changeType(oldQuestion, type);

    if (!newQuestion) {
      return null;
    }

    questions[index] = newQuestion;

    return questions;
  }

  handleOnAddQuestionBtnClick = () => {
    let questions = this.state.questions.map(q => q.getCopy());
    questions.push(new Question(++this.lastNumber));
    this.setState({ editingQuestionNumber : this.lastNumber, questions : questions });
    this.errors.push(new QuestionError());
    this.props.handleOnQuestionsArraySave(questions, this.errors);
    this.props.handleOnEditingQuestionNumberChange(this.lastNumber);
  }

  handleOnDeleteClick = () => {
    let questions = this.state.questions.map(q => q.getCopy());
    let index = questions.findIndex(q => q.number == this.state.editingQuestionNumber);
    questions.splice(index, 1);
    this.errors.splice(index, 1);
    this.setState({ editingQuestionNumber : -1, questions : questions });
    this.props.handleOnQuestionsArraySave(questions, this.errors);
    this.props.handleOnEditingQuestionNumberChange(-1);
  }

  handleOnQuestionSave = (question, errors) => {
    let questionsBuffer = this.state.questionsBuffer.map(q => q.getCopy());
    let index = questionsBuffer.findIndex(q => q.number == this.state.editingQuestionNumber);
    questionsBuffer[index] = question;
    let questions = questionsBuffer.map(q => q.getCopy());
    this.setState({ editingQuestionNumber : -1, questions : questions, questionsBuffer : questionsBuffer });
    this.errors[index] = errors;
    this.props.handleOnQuestionsArraySave(questions, this.errors);
    this.props.handleOnEditingQuestionNumberChange(-1);
  }

  handleOnEditingQuestionNumberChange = (number) => {
    let resetBuffer = this.state.questions.map(q => q.getCopy());
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
                  id={question.number}
                  index={index}
                  moveQuestion={this.moveQuestion}
                >
                  <NonEditingQuestionWrapper
                    question={question}
                    moveQuestion={this.moveQuestion}
                    handleOnQuestionSave={this.handleOnQuestionSave}
                    handleOnEditingQuestionNumberChange={this.handleOnEditingQuestionNumberChange}
                    editing={false}
                    errors = {this.errors[index]}
                  />
                </DraggableQuestion>
              );
            }

            return (
              <DraggableQuestion
                key={index}
                id={question.number}
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
                  errors = {this.errors[index]}
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
  questions : PropTypes.arrayOf(PropTypes.instanceOf(Question)).isRequired,
  errors : PropTypes.arrayOf(PropTypes.instanceOf(QuestionError)).isRequired,
  handleOnQuestionsArraySave : PropTypes.func.isRequired,
  handleOnEditingQuestionNumberChange : PropTypes.func.isRequired,
  editingQuestionNumber : PropTypes.number.isRequired,
  newEditingQuestionType: PropTypes.string,
};

export default DragDropContext(HTML5Backend)(QuestionList);
