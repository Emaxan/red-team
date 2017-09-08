import React, { Component } from 'react';
import { Panel, Col, FormGroup, FormControl } from 'react-bootstrap';
import PropTypes from 'prop-types';

import Question from '../../models/Question';
import QuestionError from '../../models/QuestionError';
import { validateMetaInfo } from '../../../utils/validation/questionValidation';
import { reactBootstrapValidationUtility as rbValidationUtility } from '../../../utils/validation/reactBootstrapValidationUtility';

export class TextQuestion extends Component {
  constructor(props) {
    super(props);

    let question = this.props.question.getCopy();

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

  handleOnOptionChange = (optionId, value) => {
    let question = this.state.question.getCopy();
    question.metaInfo[optionId] = value;
    this.setState({question});
    rbValidationUtility.setValidationState('metaInfo', this.errors, this.validationStates, validateMetaInfo(question.metaInfo));
    this.props.handleOnQuestionUpdate(question, this.errors);
  }

  render = () => {
    return (
      <Panel>
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
  errors : PropTypes.instanceOf(QuestionError).isRequired,
  question : PropTypes.instanceOf(Question).isRequired,
  handleOnQuestionUpdate : PropTypes.func,
  editing : PropTypes.bool,
};

TextQuestion.defaultProps = {
  editing : false,
};
