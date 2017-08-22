import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { Button } from 'react-bootstrap';

import {questionComponents} from './questionTypesPresentation';

export class QuestionList extends Component {
  constructor(props) {
    super(props);
    this.state = {questions: this.props.questions};
  }
  render() {
    return (
      <div>
        {
          this.state.questions.map((question) => (
            questionComponents[question.type]()
          ))
        }
        <Button onClick={this.props.handleOnAddQuestionBtnClick}>Add question</Button>
      </div>
    );
  }
}

QuestionList.propTypes = {
  questionComponents : PropTypes.object,
  questions : PropTypes.array.isRequired,
  handleOnAddQuestionBtnClick: PropTypes.func.isRequired,
};