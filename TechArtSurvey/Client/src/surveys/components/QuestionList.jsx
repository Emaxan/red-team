import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { Button } from 'react-bootstrap';
import { DragDropContext } from 'react-dnd';
import update from 'immutability-helper';
import HTML5Backend from 'react-dnd-html5-backend';

import { NonEditingQuestionWrapper } from './questions/NonEditingQuestionWrapper';
import { EditingQuestionWrapper } from './questions/EditingQuestionWrapper';
import { getLastId } from './service';
import Question from '../models/Question';
import DraggableQuestion from './DraggableQuestion';

@DragDropContext(HTML5Backend)
export class QuestionList extends Component {
  constructor(props) {
    super(props);

    this.state = {
      questions: this.props.questions,
      editingQuestionId: -1,
    };

    this.lastId = getLastId(this.state.questions);
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
    let { questions } = this.state;
    questions.push(new Question(++this.lastId));
    this.setState({ editingQuestionId : this.lastId, questions });
    this.props.handleOnQuestionsArraySave(questions);
    this.props.handleOnEditingQuestionIdChange(this.lastId);
  }

  handleOnDeleteClick = () => {
    let { questions } = this.state;
    var index = questions.findIndex(q => q.id === this.state.editingQuestionId);
    questions.splice(index, 1);
    this.setState({ questions });
    this.props.handleOnQuestionsArraySave(questions);
  }

  handleOnQuestionSave = (question) => {
    let { questions } = this.state.questions;
    var index = questions.findIndex(q => q.id === this.state.editingQuestionId);
    questions[index] = question;
    this.setState({ questions });
    this.props.handleOnQuestionsArraySave(questions);
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
            if (this.state.editingQuestionId !== question.id) {
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
};
