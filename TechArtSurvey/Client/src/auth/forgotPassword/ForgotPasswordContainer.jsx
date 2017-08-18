import React, { Component } from 'react';
import { Form, FormGroup, FormControl, ControlLabel, Button } from 'react-bootstrap';

import { forgotPassword } from './api';

import './ForgotPasswordContainer.scss';

export class ForgotPasswordContainer extends Component {
  constructor(props) {
    super(props);

    this.state = {
      emailInput : '',
      emailError : '',
      emailValidationState : null,
    };
  }

  handleOnSubmit = (event) => {
    event.preventDefault();

    forgotPassword(this.state.emailInput)
      .then(data => {
        if (data.statusCode === 200) {
          alert('Check your email!');
        }
      });
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

  handleOnEmailChange = (event) => {
    // this.setValidationState('email', validateEmail(event.target.value));
    this.setState({ emailInput : event.target.value });
  }

  render() {
    return (
      <div className="forgot-password-container">
        <h1>Forgot password? Do not worry! Enter your e-mail below</h1>
        <Form onSubmit={this.handleOnSubmit} horizontal>
          <FormGroup validationState={this.state.emailValidationState} className="label-floating">
            <ControlLabel htmlFor="email">
              { this.state.emailError || 'Email' }
            </ControlLabel>
            <FormControl
              id="email"
              name="email"
              type="text"
              value={this.state.emailInput}
              onChange={this.handleOnEmailChange}
            />
            <FormControl.Feedback />
          </FormGroup>

          <FormGroup className="text-center">
            <Button
              type="submit"
            >
              Send
            </Button>
          </FormGroup>
        </Form>
      </div>
    );
  }
}
