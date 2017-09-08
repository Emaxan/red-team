import React, { Component } from 'react';
import { Button, Glyphicon, FormGroup, Col, Panel } from 'react-bootstrap';
import PropTypes from 'prop-types';

import { questionsFactory } from '../../questionsFactory';
import Question from '../../../models/Question';
import QuestionError from '../../../models/QuestionError';
import { isQuestionValid } from '../../service';

import './NonEditingQuestionWrapper.scss';
import './Wrapper.scss';

export class NonEditingQuestionWrapper extends Component {
  constructor(props){
    super(props);

    this.question = this.props.question.getCopy();
    this.errors = this.props.errors.getCopy();
  }

  componentWillReceiveProps = (props) => {
    this.question = props.question.getCopy();
    this.errors = props.errors.getCopy();
  }

  handleOnEditClick = () => {
    this.props.handleOnEditingQuestionNumberChange(this.question.number);
  }

  render = () =>
    <Panel  className={isQuestionValid(this.errors)? '' : 'panel-has-error'}>
      <FormGroup className="title">
        <Col sm={10} smOffset={1}>
          {
            this.props.question.title
          }
        </Col>
      </FormGroup>
      <div className="question-wrapper">
        {
          questionsFactory[this.question.type](
            this.question,
            null,
            {
              isValid : isQuestionValid(this.question),
              errors : this.errors,
            },
          )
        }
        <Button onClick={this.handleOnEditClick} className="question-wrapper__edit">
          <Glyphicon glyph="pencil" />
        </Button>
      </div>
    </Panel>
}

NonEditingQuestionWrapper.propTypes = {
  question : PropTypes.instanceOf(Question).isRequired,
  errors : PropTypes.instanceOf(QuestionError).isRequired,
  handleOnEditingQuestionNumberChange : PropTypes.func.isRequired,
};
