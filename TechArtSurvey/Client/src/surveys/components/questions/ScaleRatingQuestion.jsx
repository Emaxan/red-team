import React, { Component } from 'react';
import { Panel, Col, FormGroup, FormControl } from 'react-bootstrap';
import Nouislider from 'react-nouislider';
import PropTypes from 'prop-types';

import {
  TITLE_IS_REQUIRED,
} from '../errors';

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
  errors: PropTypes.object.isRequired,
  question: PropTypes.object.isRequired,
  handleOnQuestionUpdate: PropTypes.func.isRequired,
  editing : PropTypes.bool,
};

ScaleRatingQuestion.defaultProps = {
  editing : false,
};
