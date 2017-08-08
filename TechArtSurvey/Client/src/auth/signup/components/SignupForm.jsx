import React, { Component } from 'react';
import { PropTypes } from 'prop-types';
import { FormGroup, FormControl, ControlLabel, Button, Panel } from 'react-bootstrap';

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

    this.handleOnSubmit = this.handleOnSubmit.bind(this);

    this.setValidationState = this.setValidationState.bind(this);

    this.handleOnNameChange = this.handleOnNameChange.bind(this);
    this.handleOnEmailChange = this.handleOnEmailChange.bind(this);
    this.handleOnPasswordChange = this.handleOnPasswordChange.bind(this);
    this.handleOnConfirmationPasswordChange =
            this.handleOnConfirmationPasswordChange.bind(this);
  }

  handleOnSubmit(event) {
    event.preventDefault();
    this.props.signupRequest(this.state.user);
  }

  setValidationState(fieldName) {
    if (this.errors[fieldName] === null) {
      this.validationStates[fieldName] = 'success';
    } else {
      this.validationStates[fieldName] = 'error';
    }
  }

  makeConfirmationPasswordValidation(password, confirmationPassword) {
    this.errors.confirmationPassword =
            validateConfirmationPassword(password, confirmationPassword);
    this.setValidationState('confirmationPassword');
  }

  handleOnNameChange(event) {
    const { user } = this.state;
    user.name = event.target.value;

    this.errors.name = validateName(user.name);
    this.setValidationState('name');

    this.setState({ user });
  }

  handleOnEmailChange(event) {
    const { user } = this.state;
    user.email = event.target.value;

    this.errors.email = validateEmail(user.email);
    this.setValidationState('email');

    this.setState({ user });
  }

  handleOnPasswordChange(event) {
    const { user } = this.state;
    user.password = event.target.value;

    this.errors.password = validatePassword(user.password);
    this.setValidationState('password');

    if (this.errors.password === null) {
      this.makeConfirmationPasswordValidation(user.password,
        this.state.user.confirmationPassword);
    }

    this.setState({ user });
  }

  handleOnConfirmationPasswordChange(event) {
    const { user } = this.state;
    user.confirmationPassword = event.target.value;

    this.makeConfirmationPasswordValidation(this.state.user.password,
      user.confirmationPassword);

    this.setState({ user });
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

        <form onSubmit={this.handleOnSubmit} className="form-horizontal">
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
        </form>
      </Panel>
    );
  }
}

SignupForm.propTypes = {
  errors : PropTypes.object.isRequired,
  signupRequest : PropTypes.func.isRequired,
};
