import React, { Component } from 'react';
import { Panel, Col, FormGroup, FormControl, ControlLabel } from 'react-bootstrap';
import PropTypes from 'prop-types';

import {
  validateTitle,
} from '../../../utils/validation/questionValidation';
import Question from '../../models/Question';
import QuestionError from '../../models/QuestionError';

export class StarRatingQuestion extends Component {
  constructor(props) {
    super(props);

    let question = this.props.question.getCopy();

    if(question.metaInfo.length < 1) {
      question.metaInfo.push(0);
    }

    this.state = {
      question : question,
    };

    this.errors = this.props.errors.getCopy();

    this.validationStates = {
      title : null,
    };
  }

  componentWillMount = () => {
    this.setValidationState('title', validateTitle(this.state.question.title));
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

  handleOnClick = (number) => {
    if(!this.props.editing) return;
    let question = this.state.question.getCopy();
    question.metaInfo = [number.toString()];
    this.props.handleOnQuestionUpdate(question, this.errors);
    this.setState({question});
  }

  render = () => {
    let i = 0;
    let stars = [];
    while((i < this.state.question.metaInfo[0]) && (i < 5)) {
      stars.push('glyphicon glyphicon-star');
      i++;
    }

    while(i < 5) {
      stars.push('glyphicon glyphicon-star-empty');
      i++;
    }

    return (
      <Panel>
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
        <FormGroup>
          <Col sm={8} smOffset={1}>
            {
              stars.map((star, i) => (
                <span key={i}
                  className={star}
                  onClick={
                    () => this.handleOnClick(i+1)
                  }
                />
              ))
            }
          </Col>
        </FormGroup>
      </Panel>
    );
  }
}

StarRatingQuestion.propTypes = {
  errors : PropTypes.instanceOf(QuestionError).isRequired,
  question : PropTypes.instanceOf(Question).isRequired,
  handleOnQuestionUpdate : PropTypes.func,
  editing : PropTypes.bool,
};

StarRatingQuestion.defaultProps = {
  editing : false,
};
