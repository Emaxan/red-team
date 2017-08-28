import React, { Component } from 'react';
import { Button } from 'react-bootstrap';
import PropTypes from 'prop-types';

import { questionsFactory } from '../questionsFactory';

import './NonEditingQuestionWrapper.scss';

export class NonEditingQuestionWrapper extends Component {
  constructor(props){
    super(props);

    this.state = {
      question : { ...this.props.question },
    };
  }

  componentWillReceiveProps = (props) => {
    let question = {...props.question};
    this.setState({ question : question });
  }

  handleOnEditClick = () => {
    this.props.handleOnEditingQuestionNumberChange(this.state.question.number);
  }

  render = () =>
    <div className = "question-wrapper">
      {
        questionsFactory[this.state.question.type](
          this.state.question,
          null,
        )
      }
      <Button onClick={this.handleOnEditClick} className="question-wrapper__edit">
        Edit
      </Button>
    </div>
}

NonEditingQuestionWrapper.propTypes = {
  question : PropTypes.object.isRequired,
  handleOnEditingQuestionNumberChange : PropTypes.func.isRequired,
};
