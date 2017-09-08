import React, { Component } from 'react';
import { Panel, Col, FormGroup } from 'react-bootstrap';
import PropTypes from 'prop-types';

import Question from '../../models/Question';
import QuestionError from '../../models/QuestionError';
import { validateMetaInfo } from '../../../utils/validation/questionValidation';
import { reactBootstrapValidationUtility as rbValidationUtility } from '../../../utils/validation/reactBootstrapValidationUtility';

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

  handleOnClick = (number) => {
    if(!this.props.editing) {
      return;
    }
    let question = this.state.question.getCopy();
    question.metaInfo = [number.toString()];
    rbValidationUtility.setValidationState('metaInfo', this.errors, this.validationStates, validateMetaInfo(question.metaInfo));
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
