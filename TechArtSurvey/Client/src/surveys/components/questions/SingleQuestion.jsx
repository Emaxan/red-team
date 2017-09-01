import React, { Component } from 'react';
import { Panel, Col, FormGroup, FormControl, Button, Radio, ControlLabel } from 'react-bootstrap';
import PropTypes from 'prop-types';

import {
  validateTitle,
} from '../../../utils/validation/questionValidation';

import './SingleQuestion.scss';
import './Question.scss';

export class SingleQuestion extends Component {
  constructor(props) {
    super(props);

    let { question } = this.props;
    question.metaInfo = this.props.question.metaInfo.map(m => m);

    this.state = {
      question : question,
    };

    this.errors = { ...this.props.errors };

    this.validationStates = {
      title : null,
    };
  }

  componentWillMount = () => {
    this.setValidationState('title', validateTitle(this.state.question.title));
  }

  componentWillReceiveProps = (props) => {
    let { question } = props;
    question.metaInfo = props.question.metaInfo.map(m => m);

    this.setState({
      question : question,
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
    let title = event.target.value;

    this.setValidationState('title', validateTitle(title));

    let question = { ...this.state.question };
    question.title = title;

    this.props.handleOnQuestionUpdate(question, this.errors);

    this.setState({
      question : { ...this.state.question, title : title },
    });
  }

  handleOnOptionChange = (optionId, value) => {
    let metaInfo = this.state.question.metaInfo.map(m => m);
    metaInfo[optionId] = value;
    this.setState({ question : { ...this.state.question, metaInfo : metaInfo } });
    let question = {...this.state.question};
    question.metaInfo = metaInfo;
    this.props.handleOnQuestionUpdate(question, this.state.errors);
  }

  handleOnAddOption = () => {
    let metaInfo = this.state.question.metaInfo.map(m => m);
    metaInfo.push('');
    this.setState({ question : { ...this.state.question, metaInfo : metaInfo } });
    let question = {...this.state.question};
    question.metaInfo = metaInfo;
    this.props.handleOnQuestionUpdate(question, this.state.errors);
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
  errors : PropTypes.shape({
    question : PropTypes.shape({
      title : PropTypes.string.isRequired,
      metaInfo : PropTypes.arrayOf(String).isRequired,
    }).isRequired,
  question : PropTypes.shape({
    isRequired : PropTypes.bool.isRequired,
    metaInfo : PropTypes.arrayOf(String).isRequired,
    number : PropTypes.number.isRequired,
    title : PropTypes.string.isRequired,
    type : PropTypes.string.isRequired,
  }).isRequired,
  handleOnQuestionUpdate : PropTypes.func,
  editing : PropTypes.bool,
  isValid : PropTypes.bool,
};

SingleQuestion.defaultProps = {
  editing : false,
  isValid : true,
};
