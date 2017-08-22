import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { Form, FormGroup, FormControl, ControlLabel, Button } from 'react-bootstrap';
import { isEmpty } from 'lodash';

import { validateEmail } from '../../../utils/validation/userValidation';

export class ForgotPasswordForm extends Component {
  constructor(props) {
    super(props);

    this.state = {
      emailInput : '',
    };

    this.emailError = '';
    this.emailValidationState = null;
  }

  handleOnSubmit = (event) => {
    event.preventDefault();
    this.props.forgotPasswordRequest(this.state.emailInput);
  }

  setValidationState = (validationInfo) => {
    if (validationInfo.isValid) {
      this.emailError = null;
      this.emailValidationState = 'success';
    } else {
      this.emailError = validationInfo.errors[0].message;
      this.emailValidationState = 'error';
    }
  }

  setInvalidValidationState = (message) => {
    this.emailError = message;
    this.emailValidationState = 'error';
  }

  handleOnEmailChange = (event) => {
    this.setValidationState(validateEmail(event.target.value));
    this.setState({ emailInput : event.target.value });
  }

  handleOnEmailBlur = async (event) => {
    const email = event.target.value;
    if (!isEmpty(email)) {
      await this.props.checkEmailExistenceRequest(email);

      if (!this.props.isEmailRegistered) {
        this.setInvalidValidationState('User with this email doesn\'t exists');
        this.setState({ emailInput : email });
      }
    }
  }

  render() {
    return (
      <Form onSubmit={this.handleOnSubmit} horizontal>
        <FormGroup validationState={this.emailValidationState} className="label-floating">
          <ControlLabel htmlFor="email">
            { this.emailError || 'Email' }
          </ControlLabel>
          <FormControl
            id="email"
            name="email"
            type="text"
            value={this.state.emailInput}
            onChange={this.handleOnEmailChange}
            onBlur={this.handleOnEmailBlur}
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
    );
  }
}

ForgotPasswordForm.propTypes = {
  checkEmailExistenceRequest : PropTypes.func.isRequired,
  forgotPasswordRequest : PropTypes.func.isRequired,
  isEmailRegistered : PropTypes.bool.isRequired,
};
