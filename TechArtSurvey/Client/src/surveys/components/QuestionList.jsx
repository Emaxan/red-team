import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { Button } from 'react-bootstrap';
import { DragDropContext } from 'react-dnd';
import HTML5Backend from 'react-dnd-html5-backend';
import update from 'immutability-helper';

import { NonEditingQuestionWrapper } from './questions/NonEditingQuestionWrapper';
import { EditingQuestionWrapper } from './questions/EditingQuestionWrapper';
import { getLastId } from './service';
import Question from '../models/Question';
import DraggableQuestion from './DraggableQuestion';

class QuestionList extends Component {
  constructor(props) {
    super(props);

    let questions = this.props.questions.map(q => {return {...q};});

    this.state = {
      questions : questions,
      editingQuestionId : -1,
    };

    this.lastId = getLastId(this.state.questions);
  }

  componentWillReceiveProps = (props) => {
    let questions = props.questions.map(q => {return {...q};});
    this.setState({ questions : questions, editingQuestionId : props.editingQuestionId });
  }

  moveQuestion = (dragIndex, hoverIndex) => {
    const { questions } = this.state;
    const dragQuestion = questions[dragIndex];

    this.setState(update(this.state, {
      questions: {
        $splice: [
          [dragIndex, 1],
          [hoverIndex, 0, dragQuestion],
        ],
      },
    }));
  }

  handleOnEditingQuestionChange = (id) => {
    this.setState({ editingQuestionId : id });
  }

  handleOnAddQuestionBtnClick = () => {
    let questions = this.state.questions.map(q => {return {...q};});
    questions.push(new Question(++this.lastId));
    this.setState({ editingQuestionId : this.lastId, questions : questions });
    this.props.handleOnQuestionsArraySave(questions);
    this.props.handleOnEditingQuestionIdChange(this.lastId);
  }

  handleOnDeleteClick = () => {
    let questions = this.state.questions.map(q => {return {...q};});
    let index = questions.findIndex(q => q.id == this.state.editingQuestionId);
    questions.splice(index, 1);
    this.setState({ editingQuestionId : -1, questions : questions });
    this.props.handleOnQuestionsArraySave(questions);
    this.props.handleOnEditingQuestionIdChange(-1);
  }

  handleOnQuestionSave = (question) => {
    let questions = this.state.questions.map(q => {return {...q};});
    let index = questions.findIndex(q => q.id == this.state.editingQuestionId);
    questions[index] = question;
    this.setState({ editingQuestionId : -1, questions : questions });
    this.props.handleOnQuestionsArraySave(questions);
    this.props.handleOnEditingQuestionIdChange(-1);
  }

  handleOnEditingQuestionIdChange = (id) => {
    this.setState({ editingQuestionId : id });
    this.props.handleOnEditingQuestionIdChange(id);
  }

  render = () => {
    return (
      <div>
        {
          this.state.questions.map((question, index) => {
            if(this.state.editingQuestionId != question.id) {
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
                    handleOnEditingQuestionIdChange={this.handleOnEditingQuestionIdChange}
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
                  handleOnEditingQuestionIdChange={this.handleOnEditingQuestionIdChange}
                  handleOnDeleteClick={this.handleOnDeleteClick}
                  editing
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
  handleOnEditingQuestionIdChange : PropTypes.func.isRequired,
  editingQuestionId : PropTypes.number.isRequired,
};

export default DragDropContext(HTML5Backend)(QuestionList);
