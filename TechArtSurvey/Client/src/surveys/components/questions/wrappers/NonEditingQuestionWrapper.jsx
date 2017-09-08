import React, { Component } from 'react';
import { Button, Glyphicon, FormGroup, Col } from 'react-bootstrap';
import PropTypes from 'prop-types';

import { questionsFactory } from '../../questionsFactory';
import Question from '../../../models/Question';
import QuestionError from '../../../models/QuestionError';
import { validateTitle } from '../../../../utils/validation/questionValidation';
import { reactBootstrapValidationUtility as rbValidationUtility } from '../../../../utils/validation/reactBootstrapValidationUtility';
import { isQuestionValid } from '../../service';

import './NonEditingQuestionWrapper.scss';

export class NonEditingQuestionWrapper extends Component {
  constructor(props){
    super(props);

    this.state = {
      question : this.props.question.getCopy(),
      errors : this.props.errors.getCopy(),
    };

    this.validationStates = {
      title : null,
    };

    let errors = this.props.errors.getCopy();
    rbValidationUtility.setValidationState('title', errors, this.validationStates, validateTitle(this.state.question.title));
  }

  componentWillReceiveProps = (props) => {
    let question = props.question.getCopy();
    this.setState({ question : question });
  }

  handleOnEditClick = () => {
    this.props.handleOnEditingQuestionNumberChange(this.state.question.number);
  }

  isQuestionValid = () => isQuestionValid(this.state.question);

  render = () =>
    <div>
      <FormGroup validationState={this.validationStates.title}>
        <Col sm={10} smOffset={1}>
          {
            this.props.question.title
          }
        </Col>
      </FormGroup>
      <div className="question-wrapper">
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
          <Glyphicon glyph="pencil" />
        </Button>
      </div>
    </div>
}

NonEditingQuestionWrapper.propTypes = {
  question : PropTypes.instanceOf(Question).isRequired,
  errors : PropTypes.instanceOf(QuestionError).isRequired,
  handleOnEditingQuestionNumberChange : PropTypes.func.isRequired,
};
