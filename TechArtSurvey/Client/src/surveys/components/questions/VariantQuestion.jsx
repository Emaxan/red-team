import React, { Component } from 'react';
import { Col, FormGroup, FormControl, Button, Radio, Panel, Glyphicon, Checkbox } from 'react-bootstrap';
import PropTypes from 'prop-types';

import Question from '../../models/Question';
import QuestionError from '../../models/QuestionError';
import { validateMetaInfo } from '../../../utils/validation/questionValidation';
import { reactBootstrapValidationUtility as rbValidationUtility } from '../../../utils/validation/reactBootstrapValidationUtility';
import { questionTypes } from '../../questionTypes';

import './VariantQuestion.scss';

export class VariantQuestion extends Component {
  constructor(props) {
    super(props);

    this.state = {
      question : this.props.question.getCopy(),
    };

    this.validationStates = {
      metaInfo : null,
    };

    this.errors = this.props.errors.getCopy();
    rbValidationUtility.setValidationState('metaInfo', this.errors, this.validationStates, validateMetaInfo(this.state.question.metaInfo));
  }

  componentWillReceiveProps = (props) => {
    this.setState({
      question : props.question.getCopy(),
    });
    this.errors = props.errors.getCopy();
  }

  handleOnOptionChange = (optionId, value) => {
    let question = this.state.question.getCopy();
    question.metaInfo[optionId] = value;
    this.setState({question});
    rbValidationUtility.setValidationState('metaInfo', this.errors, this.validationStates, validateMetaInfo(question.metaInfo));
    this.props.handleOnQuestionUpdate(question, this.errors);
  }

  handleOnAddOption = () => {
    let question = this.state.question.getCopy();
    question.metaInfo.push('');
    this.setState({question});
    rbValidationUtility.setValidationState('metaInfo', this.errors, this.validationStates, validateMetaInfo(question.metaInfo));
    this.props.handleOnQuestionUpdate(question, this.errors);
  }

  handleOnRemoveOption = (index) => {
    let question = this.state.question.getCopy();
    if (question.metaInfo.length > 1) {
      question.metaInfo.splice(index, 1);
      this.setState({question});
      rbValidationUtility.setValidationState('metaInfo', this.errors, this.validationStates, validateMetaInfo(question.metaInfo));
      this.props.handleOnQuestionUpdate(question, this.errors);
    }
  }

  render = () => {
    return (
      <Panel>
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
                        this.state.question.type == questionTypes.SINGLE_ANSWER ?
                          (
                            <Radio id={`${this.state.question.number}.${i}`} name={this.state.question.title}>
                              <label htmlFor={`${this.state.question.number}.${i}`} className="option">{option}</label>
                            </Radio>
                          ) :
                          (
                            <Checkbox id={`${this.state.question.number}.${i}`} name={this.state.question.title}>
                              <label htmlFor={`${this.state.question.number}.${i}`} className="option">{option}</label>
                            </Checkbox>
                          )
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

VariantQuestion.propTypes = {
  errors : PropTypes.instanceOf(QuestionError).isRequired,
  question : PropTypes.instanceOf(Question).isRequired,
  handleOnQuestionUpdate : PropTypes.func,
  editing : PropTypes.bool,
  isValid : PropTypes.bool,
};

VariantQuestion.defaultProps = {
  editing : false,
  isValid : true,
};
