import React, { Component } from 'react';
import { Col, FormGroup, FormControl, Button, Radio, Panel, ControlLabel, Glyphicon } from 'react-bootstrap';
import PropTypes from 'prop-types';

import Question from '../../models/Question';
import QuestionError from '../../models/QuestionError';
import { validateTitle } from '../../../utils/validation/questionValidation';
import { reactBootstrapValidationUtility as rbValidationUtility } from '../../../utils/validation/reactBootstrapValidationUtility';

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

    rbValidationUtility.setValidationState('title', this.errors, this.validationStates, validateTitle(this.state.question.title));
  }

  componentWillReceiveProps = (props) => {
    this.setState({
      question : props.question.getCopy(),
    });
  }

  handleOnTitleChange = (event) => {
    const title = event.target.value;
    const question = this.state.question.getCopy();
    question.title = title;
    rbValidationUtility.setValidationState('title', this.errors, this.validationStates, validateTitle(title));
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

  handleOnRemoveOption = (index) => {
    let question = this.state.question.getCopy();
    question.metaInfo.splice(index, 1);
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
                        <span>
                          <FormControl
                            type='text'
                            id={'option' + i}
                            name={'option' + i}
                            value={option}
                            placeholder="Option"
                            onChange={(e) => this.handleOnOptionChange(i, e.target.value)}
                            className="option"
                          />
                          <label htmlFor={'option' + i}>
                            <Glyphicon
                              glyph="remove"
                              role="button"
                              title="Remove option"
                              onClick={() => this.handleOnRemoveOption(i)}
                            />
                          </label>
                        </span>
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
