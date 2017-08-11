import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import PropTypes from 'prop-types';
import { Form, FormGroup, FormControl, ControlLabel, Button } from 'react-bootstrap';

import Routes from '../../../app/routesConstants';
import {
  validateEmail,
  validatePassword,
} from '../../../utils/validation/userValidation.js';

import './LoginForm.scss';

export class LoginForm extends Component {
  constructor(props) {
    super(props);

    this.state = {
      user : {
        email : '',
        password : '',
      },
    };

    this.errors = {
      email : '',
      password : '',
    };

    this.validationStates = {
      email : null,
      password : null,
    };
  }

  handleOnSubmit = (event) => {
    event.preventDefault();
    this.props.loginRequest(this.state.user);
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
    this.setValidationState('email', validateEmail(event.target.value));
    this.setState({ user : { ...this.state.user, email : event.target.value }});
  }

  handleOnPasswordChange = (event) => {
    this.setValidationState('password', validatePassword(event.target.value));
    this.setState({ user : { ...this.state.user, password : event.target.value}});
  }

  isInputValid() {
    return Object.values(this.errors)
      .every((err) => err === null);
  }

  render() {
    const formValid = this.isInputValid();

    return (
      <Form onSubmit={this.handleOnSubmit} horizontal>
        <FormGroup validationState={this.validationStates.email}>
          <ControlLabel>
            {this.errors.email}
          </ControlLabel>
          <FormControl
            name="email"
            type="text"
            placeholder="Enter e-mail"
            value={this.state.user.email}
            onChange={this.handleOnEmailChange}
          />
          <FormControl.Feedback />
        </FormGroup>

        <FormGroup validationState={this.validationStates.password}>
          <ControlLabel>
            {this.errors.password}
          </ControlLabel>
          <FormControl
            name="password"
            type="password"
            placeholder="Enter password"
            value={this.state.user.password}
            onChange={this.handleOnPasswordChange}
          />
          <FormControl.Feedback />
        </FormGroup>

        <div className="login-links">
          <Link to={Routes.SignUp.path} >{Routes.SignUp.text}</Link>
          <Link to={Routes.ForgotPassword.path} >{Routes.ForgotPassword.text}</Link>
        </div>

        <FormGroup className="text-center">
          <Button
            type="submit"
            disabled={!formValid}
            title={formValid ? '' : 'All fields must be filled'}
          >
            {this.props.actionString}
          </Button>
        </FormGroup>
      </Form>
    );
  }
}

LoginForm.propTypes = {
  actionString : PropTypes.string.isRequired,
  loginRequest : PropTypes.func.isRequired,
};
