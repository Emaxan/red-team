import React, { Component } from 'react';
import { Panel, Col, FormGroup, FormControl } from 'react-bootstrap';
import PropTypes from 'prop-types';

export class SingleQuestion extends Component {
  constructor(props){
    super(props);
    this.props.question.variants = [];
    this.props.question.number = this.props.number;
  }

  handleOnTextChange = (event) => {
    var newQuestionState = this.props.question;
    newQuestionState.text = event.target.value;

    this.props.handleOnQuestionChange(newQuestionState);
  }

  render() {
    return <Panel>
      <FormGroup controlId={this.props.question.id.toString()} >
        <Col sm={10}>
          <FormControl
            type="text"
            value={this.props.question.text}
            placeholder="Enter text"
            onChange={this.handleOnTextChange}
          />
        </Col>
      </FormGroup>
    </Panel>;
  }
}

SingleQuestion.propTypes = {
  number : PropTypes.number.isRequired,
  handleOnQuestionChange: PropTypes.func.isRequired,
  question: PropTypes.object.isRequired,
};