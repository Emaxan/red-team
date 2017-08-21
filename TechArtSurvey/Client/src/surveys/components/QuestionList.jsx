import React, { Component } from 'react';
import PropTypes from 'prop-types';

export class QuestionList extends Component {
  render() {
    return (
      <div>
        {
          this.props.questions.map((question) => (
            this.props.questionComponents[question.type]()
          ))
        }
      </div>
    );
  }
}

QuestionList.propTypes = {
  questionComponents : PropTypes.object,
  questions : PropTypes.array.isRequired,
};