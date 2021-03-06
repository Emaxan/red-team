import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { Form, FormGroup, FormControl, ControlLabel, Button } from 'react-bootstrap';
import { isEmpty } from 'lodash';

import {
  validateName,
  validateEmail,
  validatePassword,
  validateConfirmationPassword,
} from '../../../utils/validation/userValidation';
import { reactBootstrapValidationUtility as rbValidationUtility } from '../../../utils/validation/reactBootstrapValidationUtility';

export class SignUpForm extends Component {
  constructor(props) {
    super(props);

    this.state = {
      user : {
        name : '',
        email : '',
        password : '',
        confirmationPassword : '',
      },
    };

    this.errors = {
      name : '',
      email : '',
      password : '',
      confirmationPassword : '',
    };

    this.validationStates = {
      name : null,
      email : null,
      password : null,
      confirmationPassword : null,
    };
  }

  handleOnSubmit = (event) => {
    event.preventDefault();
    this.props.signUpRequest(this.state.user);
  }

  setErrorValidationState = (fieldName, message) => {
    this.errors[fieldName] = message;
    this.validationStates[fieldName] = 'error';
  }

  setNullValidationState = (fieldName) => {
    this.errors[fieldName] = null;
    this.validationStates[fieldName] = null;
  }

  makeConfirmationPasswordValidation = (password, confirmationPassword) => {
    rbValidationUtility.setValidationState(
      'confirmationPassword',
      this.errors,
      this.validationStates,
      validateConfirmationPassword(password, confirmationPassword),
    );
  }

  handleOnNameChange = (event) => {
    rbValidationUtility.setValidationState(
      'name',
      this.errors,
      this.validationStates,
      validateName(event.target.value),
    );

    this.setState({ user : { ...this.state.user, name : event.target.value }});
  }

  handleOnEmailChange = (event) => {
    rbValidationUtility.setValidationState(
      'email',
      this.errors,
      this.validationStates,
      validateEmail(event.target.value),
    );

    this.setState({ user : { ...this.state.user, email : event.target.value }});
  }

  handleOnEmailBlur = async (event) => {
    this.setErrorValidationState('email', 'Checking for email existing...');

    const email = event.target.value;
    if (!isEmpty(email)) {
      await this.props.checkEmailExistenceRequest(email);

      if (this.props.isEmailRegistered === null) {
        this.setNullValidationState('email');
      } else if (this.props.isEmailRegistered) {
        this.setErrorValidationState('email', 'User with this email is already exists');
      } else {
        rbValidationUtility.setValidationState(
          'email',
          this.errors,
          this.validationStates,
          validateEmail(email),
        );
      }

      this.setState({ user : { ...this.state.user, email : email }});
    }
  }

  handleOnPasswordChange = (event) => {
    const validationInfo = validatePassword(event.target.value);

    rbValidationUtility.setValidationState(
      'password',
      this.errors,
      this.validationStates,
      validationInfo,
    );

    if (validationInfo.isValid) {
      this.makeConfirmationPasswordValidation(event.target.value,
        this.state.user.confirmationPassword);
    }

    this.setState({ user : { ...this.state.user, password : event.target.value }});
  }

  handleOnConfirmationPasswordChange = (event) => {
    this.makeConfirmationPasswordValidation(this.state.user.password, event.target.value);
    this.setState({ user : { ...this.state.user, confirmationPassword : event.target.value}});
  }

  isInputValid = () => {
    return Object.values(this.errors)
      .every((err) => err === null);
  }

  render = () => {
    const formValid = this.isInputValid();

    return (
      <Form onSubmit={this.handleOnSubmit} horizontal>
        <FormGroup validationState={this.validationStates.name} className="label-floating">
          <ControlLabel>
            {this.errors.name || 'Name'}
          </ControlLabel>
          <FormControl
            name="name"
            type="text"
            value={this.state.user.name}
            onChange={this.handleOnNameChange}
            className="form-control"
          />
          <FormControl.Feedback />
        </FormGroup>

        <FormGroup validationState={this.validationStates.email} className="label-floating">
          <ControlLabel>
            {this.errors.email || 'Email'}
          </ControlLabel>
          <FormControl
            name="email"
            type="text"
            value={this.state.user.email}
            onChange={this.handleOnEmailChange}
            onBlur={this.handleOnEmailBlur}
            className="form-control"
          />
          <FormControl.Feedback />
        </FormGroup>

        <FormGroup validationState={this.validationStates.password} className="label-floating">
          <ControlLabel>
            {this.errors.password || 'Password'}
          </ControlLabel>
          <FormControl
            name="password"
            type="password"
            value={this.state.user.password}
            onChange={this.handleOnPasswordChange}
            className="form-control"
          />
          <FormControl.Feedback />
        </FormGroup>

        <FormGroup validationState={this.validationStates.confirmationPassword} className="label-floating">
          <ControlLabel>
            {this.errors.confirmationPassword || 'Confirm password'}
          </ControlLabel>
          <FormControl
            name="confirmationPassword"
            type="password"
            value={this.state.user.confirmationPassword}
            onChange={this.handleOnConfirmationPasswordChange}
            className="form-control"
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
                'All fields must be filled'
            }
          >
            {this.props.actionString}
          </Button>
        </FormGroup>
      </Form>
    );
  }
}

SignUpForm.propTypes = {
  actionString : PropTypes.string.isRequired,
  isEmailRegistered : PropTypes.bool,
  signUpRequest : PropTypes.func.isRequired,
  checkEmailExistenceRequest : PropTypes.func.isRequired,
};
