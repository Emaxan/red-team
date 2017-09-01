import React, { Component } from 'react';
import { Panel, Col, FormGroup, FormControl } from 'react-bootstrap';
import PropTypes from 'prop-types';

import {
  TITLE_IS_REQUIRED,
} from '../errors';

export class StarRatingQuestion extends Component {
  constructor(props) {
    super(props);

    let { question } = this.props;
    question.metaInfo = this.props.question.metaInfo.map(m => m);

    if(question.metaInfo.length < 1) {
      question.metaInfo.push(0);
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

  handleOnClick = (number) => {
    this.setState({question: {...this.state.question, metaInfo : [number]}});
    let question = {...this.state.question};
    question.metaInfo = [number];
    this.props.handleOnQuestionUpdate(question, this.state.errors);
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
  errors: PropTypes.shape({
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

StarRatingQuestion.defaultProps = {
  editing : false,
};
