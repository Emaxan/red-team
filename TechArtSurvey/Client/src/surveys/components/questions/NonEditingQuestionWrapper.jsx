import React, { Component } from 'react';
import { Button } from 'react-bootstrap';
import PropTypes from 'prop-types';

import { questionsFactory } from '../questionsFactory';
import Question from '../../models/Question';
import QuestionError from '../../models/QuestionError';

import './NonEditingQuestionWrapper.scss';

export class NonEditingQuestionWrapper extends Component {
  constructor(props){
    super(props);

    this.state = {
      question : this.props.question.getCopy(),
      errors : this.props.errors.getCopy(),
    };
  }

  componentWillReceiveProps = (props) => {
    let question = props.question.getCopy();
    this.setState({ question : question });
  }

  handleOnEditClick = () => {
    this.props.handleOnEditingQuestionNumberChange(this.state.question.number);
  }

  isQuestionValid = () => {
    // WILL BE CHANGED
    return this.props.errors.title === null;
  }

  render = () =>
    <div className = "question-wrapper">
      {
        questionsFactory[this.state.question.type](
          this.state.question,
          null,
          {
            isValid : this.isQuestionValid(),
            errors : this.state.errors,
          },
        )
      }
      <Button onClick={this.handleOnEditClick} className="question-wrapper__edit">
        Edit
      </Button>
    </div>
}

NonEditingQuestionWrapper.propTypes = {
  question : PropTypes.instanceOf(Question).isRequired,
  errors : PropTypes.instanceOf(QuestionError).isRequired,
  handleOnEditingQuestionNumberChange : PropTypes.func.isRequired,
};
