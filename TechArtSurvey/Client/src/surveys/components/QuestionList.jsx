import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { Button } from 'react-bootstrap';

import { questionsFactory } from './questionsFactory';

export class QuestionList extends Component {
  render = () => {
    return (
      <div>
        {
          this.props.questions.map((question, index) => {
            question.number = index;
            return (
              questionsFactory[question.type](
                question,
                this.props.handleOnQuestionChange,
                this.props.handleOnEditingQuestionChange,
              )
            );})
        }
        <Button onClick={this.props.handleOnAddQuestionBtnClick}>Add question</Button>
      </div>
    );
  }
}

QuestionList.propTypes = {
  questionsFactory : PropTypes.object,
  questions : PropTypes.array.isRequired,
  handleOnAddQuestionBtnClick: PropTypes.func.isRequired,
  handleOnEditingQuestionChange: PropTypes.func.isRequired,
  handleOnQuestionChange: PropTypes.func.isRequired,
};
