import React, { Component } from 'react';
import {  Button } from 'react-bootstrap';
import PropTypes from 'prop-types';

import { questionsFactory } from '../questionsFactory';

export class NonEditingQuestionWrapper extends Component {
  constructor(props) {
    super(props);

    this.state = {
      question : this.props.question,
    };
  }

  handleOnEditClick = () => {
    this.props.handleOnEditingQuestionIdChange(this.state.question.id);
  }

  render = () =>
    <div className="question-wrapper">
      {
        questionsFactory[this.state.question.type](
          this.state.question,
          null,
        )
      }
      <Button onClick={this.handleOnEditClick}>
        Edit
      </Button>
    </div>
}

NonEditingQuestionWrapper.propTypes = {
  question : PropTypes.object.isRequired,
  handleOnEditingQuestionIdChange : PropTypes.func.isRequired,
};
