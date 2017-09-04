import React, { Component } from 'react';
import { Panel, Col, FormGroup, FormControl, Button, Radio, ControlLabel } from 'react-bootstrap';
import PropTypes from 'prop-types';

import {
  validateTitle,
} from '../../../utils/validation/questionValidation';
import Question from '../../models/Question';
import QuestionError from '../../models/QuestionError';

import './SingleQuestion.scss';
import './Question.scss';

export class SingleQuestion extends Component {
  constructor(props) {
    super(props);

    this.state = {
      question : this.props.question.getCopy(),
    };

    this.errors = this.props.errors.getCopy();

    this.validationStates = {
      title : null,
    };
  }

  componentWillMount = () => {
    this.setValidationState('title', validateTitle(this.state.question.title));
  }

  componentWillReceiveProps = (props) => {
    this.setState({
      question : props.question.getCopy(),
    });
  }

  setValidationState = (fieldName, validationInfo) => {
    if (validationInfo.isValid) {
      this.errors[fieldName] = null;
      this.validationStates[fieldName] = 'success';
    } else {
      this.errors[fieldName] = validationInfo.errors[0].message;
      this.validationStates[fieldName] = 'error';
    }
  }

  handleOnTitleChange = (event) => {
    const title = event.target.value;
    const question = this.state.question.getCopy();
    question.title = title;
    this.setValidationState('title', validateTitle(title));
    this.props.handleOnQuestionUpdate(question, this.errors);
    this.setState({question});
  }

  handleOnOptionChange = (optionId, value) => {
    let question = this.state.question.getCopy();
    question.metaInfo[optionId] = value;
    this.setState({question});
    this.props.handleOnQuestionUpdate(question, this.errors);
  }

  handleOnAddOption = () => {
    let question = this.state.question.getCopy();
    question.metaInfo.push('');
    this.setState({question});
    this.props.handleOnQuestionUpdate(question, this.errors);
  }

  render = () => {
    return (
      <Panel className={this.props.isValid ? '' : 'panel-has-error'}>
        <FormGroup validationState={this.validationStates.title}>
          <Col sm={10} smOffset={1}>
            {
              this.props.editing ?
                (
                  <div>
                    <ControlLabel>
                      {this.errors.title || 'Title'}
                    </ControlLabel>
                    <FormControl
                      name="title"
                      type="text"
                      placeholder="Enter title"
                      value={this.state.question.title}
                      onChange={this.handleOnTitleChange}
                    />
                  </div>
                ) :
                (
                  this.props.question.title
                )
            }
          </Col>
        </FormGroup>

        {
          this.state.question.metaInfo.map((option, i) => {
            return (
              <FormGroup key={i}>
                <Col sm={8} smOffset={1}>
                  {
                    this.props.editing ?
                      (
                        <FormControl
                          type='text'
                          name={this.state.question.title}
                          value={option}
                          placeholder="Option"
                          onChange={(e) => this.handleOnOptionChange(i, e.target.value)}
                        />
                      ) :
                      (
                        <Radio id={`${this.state.question.number}.${i}`} name={this.state.question.title}>
                          <label htmlFor={`${this.state.question.number}.${i}`} className="option">{option}</label>
                        </Radio>
                      )
                  }
                </Col>
              </FormGroup>
            );
          })
        }

        {
          this.props.editing &&
          (
            <FormGroup className="text-center">
              <Button onClick={this.handleOnAddOption}>
                Add option
              </Button>
            </FormGroup>
          )
        }
      </Panel>
    );
  }
}

SingleQuestion.propTypes = {
  errors : PropTypes.instanceOf(QuestionError).isRequired,
  question : PropTypes.instanceOf(Question).isRequired,
  handleOnQuestionUpdate : PropTypes.func,
  editing : PropTypes.bool,
  isValid : PropTypes.bool,
};

SingleQuestion.defaultProps = {
  editing : false,
  isValid : true,
};
