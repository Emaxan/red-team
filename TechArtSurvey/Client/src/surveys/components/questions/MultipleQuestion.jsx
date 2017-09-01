import React, { Component } from 'react';
import { Panel, Col, FormGroup, FormControl, Button, Checkbox } from 'react-bootstrap';
import PropTypes from 'prop-types';

import {
  TITLE_IS_REQUIRED,
} from '../errors';

import './MultipleQuestion.scss';

export class MultipleQuestion extends Component {
  constructor(props) {
    super(props);

    let { question } = this.props;
    question.metaInfo = this.props.question.metaInfo.map(m => m);

    this.state = {
      question : question,
      errors : {
        question : {...this.props.errors},
      },
    };
  }

  handleOnTitleChange = (event) => {
    let title = event.target.value;
    let question = {...this.state.question};
    question.title = title;
    let errors = {...this.state.errors};
    if(title.trim().length === 0) {
      errors.question.title = TITLE_IS_REQUIRED;
    } else {
      errors.question.title = null;
    }
    this.props.handleOnQuestionUpdate(question, errors);
    this.setState({
      question : { ...this.state.question, title : title },
      errors : {...this.state.errors, question : errors},
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
      <Panel>
        <FormGroup>
          <Col sm={10} smOffset={1}>
            {
              this.props.editing ?
                (
                  <FormControl
                    name="title"
                    type="text"
                    value={this.state.question.title}
                    placeholder="Enter question's title"
                    onChange={this.handleOnTitleChange}
                  />
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
                        <Checkbox id={`${this.state.question.number}.${i}`} name={this.state.question.title}>
                          <label htmlFor={`${this.state.question.number}.${i}`} className="option">{option}</label>
                        </Checkbox>
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

MultipleQuestion.propTypes = {
  errors : PropTypes.shape({
    question : PropTypes.shape({
      title : PropTypes.string.isRequired,
      metaInfo : PropTypes.arrayOf(String).isRequired,
    }).isRequired,
  question: PropTypes.shape({
    isRequired : PropTypes.bool.isRequired,
    metaInfo : PropTypes.arrayOf(String).isRequired,
    number : PropTypes.number.isRequired,
    title : PropTypes.string.isRequired,
    type : PropTypes.string.isRequired,
  }).isRequired,
  handleOnQuestionUpdate: PropTypes.func.isRequired,
  editing : PropTypes.bool,
};

MultipleQuestion.defaultProps = {
  editing : false,
};
