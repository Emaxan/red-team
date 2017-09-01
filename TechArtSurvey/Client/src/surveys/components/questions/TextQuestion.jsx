import React, { Component } from 'react';
import { Panel, Col, FormGroup, FormControl } from 'react-bootstrap';
import PropTypes from 'prop-types';

import {
  TITLE_IS_REQUIRED,
} from '../errors';

export class TextQuestion extends Component {
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

        <FormGroup>
          <Col sm={8} smOffset={1}>
            {
              this.props.editing ?
                (
                  <FormControl
                    type='text'
                    name={this.state.question.title}
                    value={this.state.question.metaInfo[0]}
                    placeholder="Option"
                    onChange={(e) => this.handleOnOptionChange(0, e.target.value)}
                  />
                ) :
                (
                  <textarea
                    className="form-control"
                    rows="5"
                    name={this.state.question.title}
                    placeholder={this.state.question.metaInfo[0]}
                    onChange={(e) => this.handleOnOptionChange(0, e.target.value)}
                  />
                )
            }
          </Col>
        </FormGroup>
      </Panel>
    );
  }
}

TextQuestion.propTypes = {
  errors : PropTypes.shape({
    question : PropTypes.shape({
      title : PropTypes.string.isRequired,
      metaInfo : PropTypes.arrayOf(String).isRequired,
    }).isRequired,
  }).isRequired,
  question : PropTypes.shape({
    isRequired : PropTypes.bool.isRequired,
    metaInfo : PropTypes.arrayOf(String).isRequired,
    number : PropTypes.number.isRequired,
    title : PropTypes.string.isRequired,
    type : PropTypes.string.isRequired,
  }).isRequired,
  handleOnQuestionUpdate : PropTypes.func.isRequired,
  editing : PropTypes.bool,
};

TextQuestion.defaultProps = {
  editing : false,
};
