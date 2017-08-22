import React, { Component } from 'react';
import { Panel, Form, Col, FormGroup, FormControl } from 'react-bootstrap';
import PropTypes from 'prop-types';

export class SingleQuestion extends Component {
  constructor(props){
    super(props);
    this.state = {question: {
      text: '',
      variants: [],
      isRequired: false,
      number: this.props.number,
    }};
  }

  handleOnTitleChange = () => {

  }

  render() {
    return <Panel>
      <Form horizontal>
        <FormGroup controlId="title" >
          <Col sm={10}>
            <FormControl
              type="text"
              value={this.state.survey.title}
              placeholder="Enter text"
              onChange={this.handleOnTitleChange}
            />
          </Col>
        </FormGroup>
      </Form>
    </Panel>;
  }
}

SingleQuestion.propTypes = {
  number : PropTypes.number.isRequired,
};