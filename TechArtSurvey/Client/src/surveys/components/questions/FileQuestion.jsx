import React, { Component } from 'react';
import { Panel } from 'react-bootstrap';
import PropTypes from 'prop-types';

export class FileQuestion extends Component {
  constructor(props){
    super(props);
  }

  handleOnTextChange = (event) => {
    var newQuestionState = this.props.question;
    newQuestionState.text = event.target.value;

    this.props.handleOnQuestionChange(newQuestionState);
  }

  render = () => {
    return (
      <Panel>
      fiiiile
      </Panel>
    );
  }
}

FileQuestion.propTypes = {
  handleOnQuestionChange: PropTypes.func.isRequired,
  question: PropTypes.object.isRequired,
};
