import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { Button } from 'react-bootstrap';

import {questionComponents} from './questionTypesPresentation';

export class QuestionList extends Component {
  render() {
    return (
      <div>
        {
          this.props.questions.map((question, index) => (
            questionComponents[question.type](
              question,
              index,
              this.props.handleOnQuestionChange,
            )
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
  handleOnQuestionChange: PropTypes.func.isRequired,
};