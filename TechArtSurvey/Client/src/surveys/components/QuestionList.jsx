import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { Button } from 'react-bootstrap';
import { DragDropContext } from 'react-dnd';
import HTML5Backend from 'react-dnd-html5-backend';
import update from 'immutability-helper';

// import DraggableQuestion from './questions/dnd/DraggableQuestion';
import NonEditingQuestionWrapper from './questions/wrappers/NonEditingQuestionWrapper';
import EditingQuestionWrapper from './questions/wrappers/EditingQuestionWrapper';
import { getLastNumber, changeQuestionType } from './service';
import Question from '../models/Question';
import QuestionError from '../models/QuestionError';

class QuestionList extends Component {
  constructor(props) {
    super(props);

    this.state = {
      questions : this.props.questions.map(q => q.getCopy()),
      questionsBuffer :  this.props.questions.map(q => q.getCopy()),
      editingQuestionNumber : 0,
    };

    this.editingQuestionType = this.props.newEditingQuestionType;
    this.lastNumber = getLastNumber(this.state.questions);
    this.errors = this.props.errors;
  }

  componentWillReceiveProps = (props) => {
    this.errors = props.errors;

    let questions = props.questions.map(q => q.getCopy());
    let questionsBuffer = props.questions.map(q => q.getCopy());

    if (props.newEditingQuestionType !== this.editingQuestionType) {
      this.editingQuestionType = props.newEditingQuestionType;
      let newQuestions = this.changeQuestionsOnQuestionTypeChange(questions, props.newEditingQuestionType);
      if (newQuestions) {
        questionsBuffer = newQuestions;
      }
    }

    this.setState({ questions, questionsBuffer, editingQuestionNumber : props.editingQuestionNumber });
  }

  handleOnAddQuestionClick = () => {
    let questions = this.state.questions.map(q => q.getCopy());
    questions.push(new Question(++this.lastNumber));
    this.setState({ editingQuestionNumber : this.lastNumber, questions });
    this.errors.push(new QuestionError());
    this.props.handleOnQuestionsArraySave(questions, this.errors);
    this.props.handleOnEditingQuestionNumberChange(this.lastNumber);
  }

  handleOnDeleteQuestionClick = () => {
    let questions = this.state.questions.map(q => q.getCopy());
    let index = questions.findIndex(q => q.number === this.state.editingQuestionNumber);
    questions.splice(index, 1);
    this.errors.splice(index, 1);
    this.setState({ editingQuestionNumber : -1, questions : questions });
    this.props.handleOnQuestionsArraySave(questions, this.errors);
    this.props.handleOnEditingQuestionNumberChange(-1);
  }

  handleOnQuestionSaveClick = (question, errors) => {
    let questionsBuffer = this.state.questionsBuffer.map(q => q.getCopy());
    let index = questionsBuffer.findIndex(q => q.number === this.state.editingQuestionNumber);
    questionsBuffer[index] = question;
    let questions = questionsBuffer.map(q => q.getCopy());
    this.setState({ editingQuestionNumber : -1, questions, questionsBuffer });
    this.errors[index] = errors;
    this.props.handleOnQuestionsArraySave(questions, this.errors);
    this.props.handleOnEditingQuestionNumberChange(-1);
  }

  handleOnEditingQuestionNumberChange = (number) => {
    let resetBuffer = this.state.questions.map(q => q.getCopy());
    this.setState({ editingQuestionNumber : number, questionsBuffer : resetBuffer });
    this.props.handleOnEditingQuestionNumberChange(number);
  }

  changeQuestionsOnQuestionTypeChange = (oldQuestions, type) => {
    if (!type || type.length === 0) {
      return null;
    }

    let questions = oldQuestions.map(q => q.getCopy());
    let index = questions.findIndex(q => q.number === this.state.editingQuestionNumber);
    let oldQuestion = questions[index].getCopy();
    let newQuestion = changeQuestionType(oldQuestion, type);

    if (!newQuestion) {
      return null;
    }

    questions[index] = newQuestion;

    return questions;
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

    const temp = this.errors[dragIndex];
    this.errors[dragIndex] = this.errors[hoverIndex];
    this.errors[hoverIndex] = temp;

    this.props.handleOnQuestionsArraySave(questions, this.errors, false);
  }

  render = () => {
    return (
      <div>
        {
          this.state.questionsBuffer.map((question, index) => {
            if (this.state.editingQuestionNumber !== question.number) {
              return (
                <NonEditingQuestionWrapper
                  key={question.number}
                  id={question.number}
                  index={index}
                  question={question}
                  moveQuestion={this.moveQuestion}
                  handleOnQuestionSave={this.handleOnQuestionSaveClick}
                  handleOnEditingQuestionNumberChange={this.handleOnEditingQuestionNumberChange}
                  editing={false}
                  errors={this.errors[index]}
                />
              );
            }

            return (
              <EditingQuestionWrapper
                key={question.number}
                id={question.number}
                index={index}
                question={question}
                moveQuestion={this.moveQuestion}
                handleOnQuestionSave={this.handleOnQuestionSaveClick}
                handleOnEditingQuestionNumberChange={this.handleOnEditingQuestionNumberChange}
                handleOnDeleteClick={this.handleOnDeleteQuestionClick}
                editing
                errors={this.errors[index]}
              />
            );
          })
        }
        <Button onClick={this.handleOnAddQuestionClick}>Add question</Button>
      </div>
    );
  }
}

{/* <DraggableQuestion
                  key={index}
                  id={question.number}
                  index={index}
                  moveQuestion={this.moveQuestion}
                  canDrag={false}
                >

                </DraggableQuestion> */}

{/* <DraggableQuestion
                key={index}
                id={question.number}
                index={index}
                moveQuestion={this.moveQuestion}
                canDrag={true}
              >
                
              </DraggableQuestion> */}

QuestionList.propTypes = {
  questions : PropTypes.arrayOf(PropTypes.instanceOf(Question)).isRequired,
  errors : PropTypes.arrayOf(PropTypes.instanceOf(QuestionError)).isRequired,
  handleOnQuestionsArraySave : PropTypes.func.isRequired,
  handleOnEditingQuestionNumberChange : PropTypes.func.isRequired,
  editingQuestionNumber : PropTypes.number.isRequired,
  newEditingQuestionType: PropTypes.string,
};

export default DragDropContext(HTML5Backend)(QuestionList);
