import React, { Component } from 'react';
import { Panel, Button } from 'react-bootstrap';
import PropTypes from 'prop-types';

import { questionsFactory } from '../questionsFactory';

export class NonEditingQuestionWrapper extends Component {
  constructor(props){
    super(props);
    this.state = {
      question: this.props.question,
    };
  }

  handleOnTextChange = (event) => {
    var newQuestionState = this.props.question;
    newQuestionState.text = event.target.value;

    this.props.handleOnQuestionChange(newQuestionState);
  }

  handleOnEditClick = () => {
    this.props.handleOnEditingQuestionChange(this.state.question.id);
  }

  render = () =>
    <Panel>
      {
        questionsFactory[this.state.question.type](
          this.state.question,
          this.props.handleOnQuestionChange,
        )
      }
      <Button onClick={this.handleOnEditClick}>
            Edit
      </Button>
    </Panel>
}

NonEditingQuestionWrapper.propTypes = {
  handleOnQuestionChange: PropTypes.func.isRequired,
  question: PropTypes.object.isRequired,
  handleOnEditingQuestionChange: PropTypes.func.isRequired,
};
