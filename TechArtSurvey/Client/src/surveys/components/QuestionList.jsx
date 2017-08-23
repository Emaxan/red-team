import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { Button } from 'react-bootstrap';

import { NonEditingQuestionWrapper } from './questions/NonEditingQuestionWrapper';
import { EditingQuestionWrapper } from './questions/EditingQuestionWrapper';

export class QuestionList extends Component {
  render = () => {
    return (
      <div>
        {
          this.props.questions.map((question, index) => { console.log('editing: '+this.props.editingQuestionId + ' question: '+question.id);
            if(this.props.editingQuestionId != question.id) {
              return <NonEditingQuestionWrapper
                key = {index}
                question = {question}
                handleOnQuestionChange = {this.props.handleOnQuestionChange}
                handleOnEditingQuestionChange = {this.props.handleOnEditingQuestionChange}
              />;
            }
            return <EditingQuestionWrapper
              key = {index}
              question = {question}
              handleOnQuestionChange = {this.props.handleOnQuestionChange}
              handleOnEditingQuestionChange = {this.props.handleOnEditingQuestionChange}
            />;
          })
        }
        <Button onClick={this.props.handleOnAddQuestionBtnClick}>Add question</Button>
      </div>
    );
  }
}

QuestionList.propTypes = {
  questions : PropTypes.array.isRequired,
  handleOnAddQuestionBtnClick: PropTypes.func.isRequired,
  handleOnEditingQuestionChange: PropTypes.func.isRequired,
  handleOnQuestionChange: PropTypes.func.isRequired,
  editingQuestionId: PropTypes.number.isRequired,
};
