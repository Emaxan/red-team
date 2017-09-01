import React, { Component } from 'react';
import { Panel, Col, FormGroup, FormControl, ControlLabel } from 'react-bootstrap';
import Nouislider from 'react-nouislider';
import PropTypes from 'prop-types';

import {
  validateTitle,
} from '../../../utils/validation/questionValidation';

import './ScaleRatingQuestion.scss';

export class ScaleRatingQuestion extends Component {
  constructor(props) {
    super(props);

    let { question } = this.props;
    question.metaInfo = this.props.question.metaInfo.map(m => m);

    if(question.metaInfo.length<1){
      question.metaInfo.push('50');
    }

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
    const question = { ...this.state.question, title };

    this.setValidationState('title', validateTitle(title));
    this.props.handleOnQuestionUpdate(question, this.errors);
    this.setState({
      question : { ...this.state.question, title : title },
    });
  }

  handleOnValueChange = (value) => {
    if(!this.props.editing) {
      this.props.handleOnQuestionUpdate(this.state.question, this.state.errors);
      return;
    }
    this.setState({question : {...this.state.question, metaInfo : [value[0].toString()]}});
    let question = {...this.state.question};
    question.metaInfo = [value[0].toString()];
    this.props.handleOnQuestionUpdate(question, this.state.errors);
  }

  render = () => {
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
            <Nouislider
              animate={true}
              animationDuration={300}
              range={{
                min: 0,
                max: 100,
              }}
              start={[Number(this.state.question.metaInfo[0])]}
              connect={[true, false]}
              step={1}
              tooltips
              pips={{
                mode: 'steps',
                filter: function ( value ) {
                  return ((value % 5) ? 0 : 2);
                },
              }}
              onChange={this.handleOnValueChange}
            />
          </Col>
        </FormGroup>
      </Panel>
    );
  }
}

ScaleRatingQuestion.propTypes = {
  errors: PropTypes.shape({
    question : PropTypes.shape({
      title : PropTypes.string.isRequired,
      metaInfo : PropTypes.string.isRequired,
    }),
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

ScaleRatingQuestion.defaultProps = {
  editing : false,
};
