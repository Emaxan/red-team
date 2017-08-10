import React, { Component } from 'react';
import PropTypes from 'prop-types';
import ImmutablePropTypes from 'react-immutable-proptypes';
import { Form, FormGroup, FormControl, ControlLabel, Button, Panel } from 'react-bootstrap';

import {
  validateName,
  validateEmail,
  validatePassword,
  validateConfirmationPassword,
} from '../../../utils/validation/userValidation.js';

import './SignupForm.scss';

export class SignupForm extends Component {
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
    this.props.signupRequest(this.state.user);
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
      <Panel className="col-md-6 col-md-offset-3">
        <h2 className="signup__title">Sign Up</h2>
        <FormGroup>
          {
            this.props.errors.map((error, i) => (
              <FormControl.Static key={i} className="text-danger">
                <strong>{error}</strong>
              </FormControl.Static>
            ))
          }
        </FormGroup>

        <Form onSubmit={this.handleOnSubmit} horizontal>
          <FormGroup validationState={this.validationStates.name}>
            <ControlLabel hidden={!this.errors.name}>
              {this.errors.name}
            </ControlLabel>
            <FormControl
              name="name"
              type="text"
              placeholder="Enter name"
              value={this.state.user.name}
              onChange={this.handleOnNameChange}
              className="form-control"
            />
          </FormGroup>

          <FormGroup validationState={this.validationStates.email}>
            <ControlLabel hidden={!this.errors.email}>
              {this.errors.email}
            </ControlLabel>
            <FormControl
              name="email"
              type="text"
              placeholder="Enter e-mail"
              value={this.state.user.email}
              onChange={this.handleOnEmailChange}
              onBlur={this.handleOnEmailBlur}
              className="form-control"
            />
          </FormGroup>

          <FormGroup validationState={this.validationStates.password}>
            <ControlLabel hidden={!this.errors.password}>
              {this.errors.password}
            </ControlLabel>
            <FormControl
              name="password"
              type="password"
              placeholder="Enter password"
              value={this.state.user.password}
              onChange={this.handleOnPasswordChange}
              className="form-control"
            />
          </FormGroup>

          <FormGroup validationState={this.validationStates.confirmationPassword}>
            <ControlLabel hidden={!this.errors.confirmationPassword}>
              {this.errors.confirmationPassword}
            </ControlLabel>
            <FormControl
              name="confirmationPassword"
              type="password"
              placeholder="Confirm password"
              value={this.state.user.confirmationPassword}
              onChange={this.handleOnConfirmationPasswordChange}
              className="form-control"
            />
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
              Create account
            </Button>
          </FormGroup>
        </Form>
      </Panel>
    );
  }
}

SignupForm.propTypes = {
  errors : ImmutablePropTypes.list.isRequired,
  signupRequest : PropTypes.func.isRequired,
  checkEmailExistenceRequest : PropTypes.func.isRequired,
};
