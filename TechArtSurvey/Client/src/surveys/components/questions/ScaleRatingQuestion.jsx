import React, { Component } from 'react';
import { Panel, Col, FormGroup } from 'react-bootstrap';
import Nouislider from 'react-nouislider';
import PropTypes from 'prop-types';

import Question from '../../models/Question';
import QuestionError from '../../models/QuestionError';
import { validateMetaInfo } from '../../../utils/validation/questionValidation';
import { reactBootstrapValidationUtility as rbValidationUtility } from '../../../utils/validation/reactBootstrapValidationUtility';

import './ScaleRatingQuestion.scss';

export class ScaleRatingQuestion extends Component {
  constructor(props) {
    super(props);

    let question = this.props.question.getCopy();

    if(question.metaInfo.length<1){
      question.metaInfo.push('50');
    }

    this.state = {
      question : question,
    };

    this.validationStates = {
      metaInfo : null,
    };

    this.errors = this.props.errors.getCopy();
    rbValidationUtility.setValidationState('metaInfo', this.errors, this.validationStates, validateMetaInfo(question.metaInfo));
  }

  componentWillReceiveProps = (props) => {
    this.setState({
      question : props.question.getCopy(),
    });
    this.errors = props.errors.getCopy();
  }

  handleOnValueChange = (value) => {
    if(!this.props.editing) {
      return;
    }
    let question = this.state.question.getCopy();
    question.metaInfo = [value[0].toString()];
    this.setState({question});
    rbValidationUtility.setValidationState('metaInfo', this.errors, this.validationStates, validateMetaInfo(question.metaInfo));
    this.props.handleOnQuestionUpdate(question, this.errors);
  }

  render = () => {
    return (
      <Panel>
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
  errors : PropTypes.instanceOf(QuestionError).isRequired,
  question : PropTypes.instanceOf(Question).isRequired,
  handleOnQuestionUpdate : PropTypes.func,
  editing : PropTypes.bool,
};

ScaleRatingQuestion.defaultProps = {
  editing : false,
};
