import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import PropTypes from 'prop-types';
import ImmutablePropTypes from 'react-immutable-proptypes';
import { Form, FormGroup, FormControl, ControlLabel, Button, Panel } from 'react-bootstrap';

import Routes from '../../../app/routesConstants';
import {
  validateEmail,
  validatePassword,
} from '../../../utils/validation/userValidation.js';

import './LogInForm.scss';

export class LogInForm extends Component {
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
    this.props.logInRequest(this.state.user);
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
    const { user } = this.state;
    user.email = event.target.value;
    this.setValidationState('email', validateEmail(user.email));
    this.setState({ user });
  }

  handleOnPasswordChange = (event) => {
    const { user } = this.state;
    user.password = event.target.value;

    const validationInfo = validatePassword(user.password);
    this.setValidationState('password', validationInfo);

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
        <h2 className="login__title">Log In</h2>
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
            />
          </FormGroup>
          <div className="logIn-links">
            <Link to={Routes.SignUp.path} >{Routes.SignUp.text}</Link>
            <Link to={Routes.ForgotPassword.path} >{Routes.ForgotPassword.text}</Link>
          </div>
          <FormGroup className="text-center">
            <Button
              type="submit"
              disabled={!formValid}
              title={formValid ? '' : 'All fields must be filled'}
            >
                LogIn
            </Button>
          </FormGroup>
        </Form>
      </Panel>
    );
  }
}

LogInForm.propTypes = {
  errors : ImmutablePropTypes.list.isRequired,
  logInRequest : PropTypes.func.isRequired,
};
