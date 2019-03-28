import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { Form, FormGroup, FormControl, ControlLabel, Button } from 'react-bootstrap';
import { isEmpty } from 'lodash';

import { validateEmail } from '../../../utils/validation/userValidation';
import { reactBootstrapValidationUtility as rbValidationUtility } from '../../../utils/validation/reactBootstrapValidationUtility';

export class ForgotPasswordForm extends Component {
  constructor(props) {
    super(props);

    this.state = {
      emailInput : '',
    };

    this.errors = {
      email : '',
    },

    this.validationStates = {
      email : null,
    };
  }

  handleOnSubmit = (event) => {
    event.preventDefault();
    this.props.forgotPasswordRequest(this.state.emailInput);
  }

  setSuccessValidationState = () => {
    this.errors.email = null;
    this.validationStates.email = 'success';
  }

  setErrorValidationState = (message) => {
    this.errors.email = message;
    this.validationStates.email = 'error';
  }

  setNullValidationState = () => {
    this.errors.email = null;
    this.validationStates.email = null;
  }

  handleOnEmailChange = (event) => {
    rbValidationUtility.setValidationState(
      'email',
      this.errors,
      this.validationStates,
      validateEmail(event.target.value),
    );

    this.setState({ emailInput : event.target.value });
  }

  handleOnEmailBlur = async (event) => {
    this.setErrorValidationState('Checking for email existing...');

    const email = event.target.value;
    if (!isEmpty(email)) {
      await this.props.checkEmailExistenceRequest(email);

      if (this.props.isEmailRegistered === null) {
        this.setNullValidationState();
      } else if (this.props.isEmailRegistered) {
        this.setSuccessValidationState();
      } else {
        this.setErrorValidationState('User with this email doesn\'t exists');
      }

      this.setState({ emailInput : email });
    }
  }

  isInputValid = () => {
    return this.errors.email === null;
  }

  render = () => {
    const formValid = this.isInputValid();

    return (
      <Form onSubmit={this.handleOnSubmit} horizontal>
        <FormGroup validationState={this.validationStates.email} className="label-floating">
          <ControlLabel htmlFor="email">
            { this.errors.email || 'Email' }
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
            disabled={!formValid}
            title={
              formValid ?
                '' :
                'You should enter your email'
            }
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
  isEmailRegistered : PropTypes.bool,
};
