import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { Button } from 'react-bootstrap';
import { DragDropContext } from 'react-dnd';
import HTML5Backend from 'react-dnd-html5-backend';
import update from 'immutability-helper';

import NonEditingQuestionWrapper from './questions/wrappers/NonEditingQuestionWrapper';
import EditingQuestionWrapper from './questions/wrappers/EditingQuestionWrapper';
import { getLastNumber, getDefaultErrorByType } from './service';
import Question from '../models/Question';
import QuestionError from '../models/QuestionError';

class QuestionList extends Component {
  constructor(props) {
    super(props);

    this.state = {
      questions : this.props.questions.map(q => q.getCopy()),
      editingQuestionNumber : 0,
    };

    this.editingQuestionType = this.props.newEditingQuestionType;
    this.lastNumber = getLastNumber(this.state.questions);
    this.errors = this.props.errors;
  }

  componentWillReceiveProps = (props) => {
    this.errors = props.errors;

    let questions = props.questions.map(q => q.getCopy());

    if (props.newEditingQuestionType !== this.editingQuestionType) {
      this.handleOnTypeChange(props.newEditingQuestionType);
    }
    this.setState({ questions, editingQuestionNumber : props.editingQuestionNumber });
  }

  handleOnAddQuestionClick = () => {
    let questions = this.state.questions.map(q => q.getCopy());
    questions.push(new Question(++this.lastNumber));
    this.setState({ editingQuestionNumber : this.lastNumber, questions });
    this.errors.push(getDefaultErrorByType());
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
    let questions = this.state.questions.map(q => q.getCopy());
    let index = questions.findIndex(q => q.number === this.state.editingQuestionNumber);
    questions[index] = question;
    this.setState({ editingQuestionNumber : -1, questions });
    this.errors[index] = errors;
    this.props.handleOnQuestionsArraySave(questions, this.errors);
    this.props.handleOnEditingQuestionNumberChange(-1);
  }

  handleOnEditingQuestionNumberChange = (number) => {
    this.setState({ editingQuestionNumber : number });
    this.props.handleOnEditingQuestionNumberChange(number);
  }

  handleOnTypeChange = (type) => {
    if (!type || type.length === 0) {
      return null;
    }

    if(this.state.editingQuestionNumber === -1) {
      return null;
    }

    this.editingQuestionType = type;
  }

  moveQuestion = (dragIndex, hoverIndex) => {
    const dragQuestion = this.state.questions[dragIndex];

    this.setState(update(this.state, {
      questions: {
        $splice: [
          [dragIndex, 1],
          [hoverIndex, 0, dragQuestion],
        ],
      },
    }));

    let questions = this.state.questions.map(q => q.getCopy());

    [this.errors[hoverIndex], this.errors[dragIndex]] = [this.errors[dragIndex], this.errors[hoverIndex]];

    this.props.handleOnQuestionsArraySave(questions, this.errors, false);
  }

  render = () => {
    return (
      <div>
        {
          this.state.questions.map((question, index) => {
            if (this.state.editingQuestionNumber !== question.number) {
              return (
                <NonEditingQuestionWrapper
                  key={question.number}
                  index={index}
                  question={question}
                  errors={this.errors[index]}
                  moveQuestion={this.moveQuestion}
                  handleOnQuestionSave={this.handleOnQuestionSaveClick}
                  handleOnEditingQuestionNumberChange={this.handleOnEditingQuestionNumberChange}
                />
              );
            }

            return (
              <EditingQuestionWrapper
                key={question.number}
                number={question.number}
                index={index}
                question={question}
                newType={this.editingQuestionType}
                errors={this.errors[index]}
                handleOnQuestionSave={this.handleOnQuestionSaveClick}
                handleOnEditingQuestionNumberChange={this.handleOnEditingQuestionNumberChange}
                handleOnDeleteClick={this.handleOnDeleteQuestionClick}
              />
            );
          })
        }

        <Button onClick={this.handleOnAddQuestionClick}>Add question</Button>
      </div>
    );
  }
}

QuestionList.propTypes = {
  questions : PropTypes.arrayOf(PropTypes.instanceOf(Question)).isRequired,
  errors : PropTypes.arrayOf(PropTypes.instanceOf(QuestionError)).isRequired,
  editingQuestionNumber : PropTypes.number.isRequired,
  newEditingQuestionType: PropTypes.string,
  handleOnQuestionsArraySave : PropTypes.func.isRequired,
  handleOnEditingQuestionNumberChange : PropTypes.func.isRequired,
};

export default DragDropContext(HTML5Backend)(QuestionList);
