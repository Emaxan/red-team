import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { Button } from 'react-bootstrap';

import { NonEditingQuestionWrapper } from './questions/NonEditingQuestionWrapper';
import { EditingQuestionWrapper } from './questions/EditingQuestionWrapper';
import { getLastId } from './service';
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
};
