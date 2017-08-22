import React, { Component } from 'react';
import { Panel, Form, Col, FormGroup, FormControl } from 'react-bootstrap';
import PropTypes from 'prop-types';

export class FileQuestion extends Component {
  constructor(props){
    super(props);
    this.state = {question: {
      text: '',
      variants: [],
      isRequired: false,
      number: this.props.number,
    }};
  }

  handleOnTextChange = () => {

  }

  render() {
    return <Panel>
      <Form horizontal>
        <FormGroup controlId="text" >
          <Col sm={10}>
            <FormControl
              type="text"
              value={this.state.question.text}
              placeholder="Enter text"
              onChange={this.handleOnTextChange}
            />
          </Col>
        </FormGroup>
      </Form>
    </Panel>;
  }
}

FileQuestion.propTypes = {
  number : PropTypes.number.isRequired,
};