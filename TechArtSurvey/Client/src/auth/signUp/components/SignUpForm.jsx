import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { Form, FormGroup, FormControl, ControlLabel, Button } from 'react-bootstrap';

import {
  validateName,
  validateEmail,
  validatePassword,
  validateConfirmationPassword,
} from '../../../utils/validation/userValidation.js';

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

  setValidationState = (fieldName, validationInfo) => {
    if (validationInfo.isValid) {
      this.errors[fieldName] = null;
      this.validationStates[fieldName] = 'success';
    } else {
      this.errors[fieldName] = validationInfo.errors[0].message;
      this.validationStates[fieldName] = 'error';
    }
  }

  makeConfirmationPasswordValidation = (password, confirmationPassword)  =>{
    this.setValidationState('confirmationPassword', validateConfirmationPassword(password, confirmationPassword));
  }

  handleOnNameChange = (event) => {
    this.setValidationState('name', validateName(event.target.value));
    this.setState({ user : { ...this.state.user, name : event.target.value }});
  }

  handleOnEmailChange = (event) => {
    this.setValidationState('email', validateEmail(event.target.value));
    this.setState({ user : { ...this.state.user, email : event.target.value }});
  }

  handleOnEmailBlur = (event) => {
    const email = event.target.value;
    this.props.checkEmailExistenceRequest(email);
  }

  handleOnPasswordChange = (event) => {
    const validationInfo = validatePassword(event.target.value);
    this.setValidationState('password', validationInfo);

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

  isInputValid() {
    return Object.values(this.errors)
      .every((err) => err === null);
  }

  render() {
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
  signUpRequest : PropTypes.func.isRequired,
  checkEmailExistenceRequest : PropTypes.func.isRequired,
};