import React, { Component } from 'react';
// import { Link } from 'react-router-dom';
import PropTypes from 'prop-types';
import { Form, FormGroup, FormControl, ControlLabel, Button } from 'react-bootstrap';
// import Routes from '../../../app/routes';
// import {
//   validateEmail,
//   validatePassword,
// } from '../../../utils/validation/userValidation.js';

import { resetPassword } from '../api';

export class NewPasswordForm extends Component {
  constructor(props) {
    super(props);

    this.state = {
      userData : {
        newPassword : '',
        confirmationNewPassword : '',
      },
    };

    this.errors = {
      newPassword : '',
      confirmationNewPassword : '',
    };

    this.validationStates = {
      newPassword : null,
      confirmationNewPassword : null,
    };
  }

  handleOnSubmit = (event) => {
    event.preventDefault();

    resetPassword(
      this.props.userId,
      this.props.token,
      this.state.userData.newPassword,
    )
      .then(data => {
        if (data.statusCode === 200) {
          alert('Password was changes successfully!');
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

  handleOnNewPasswordChange = (event) => {
    // this.setValidationState('email', validateEmail(event.target.value));
    this.setState({ userData : { ...this.state.userData, newPassword : event.target.value }});
  }

  handleOnConfirmationNewPasswordChange = (event) => {
    // this.setValidationState('password', validatePassword(event.target.value));
    this.setState({ userData : { ...this.state.userData, confirmationNewPassword : event.target.value}});
  }

  isInputValid() {
    return true;
    // return Object.values(this.errors)
    //   .every((err) => err === null);
  }

  render() {
    // const formValid = this.isInputValid();

    return (
      <div>
        <Form onSubmit={this.handleOnSubmit} horizontal>
          <FormGroup validationState={this.validationStates.newPassword} className="label-floating">
            <ControlLabel htmlFor="newPassword">
              { this.errors.newPassword || 'New password' }
            </ControlLabel>
            <FormControl
              id="newPassword"
              name="newPassword"
              type="password"
              value={this.state.userData.newPassword}
              onChange={this.handleOnNewPasswordChange}
            />
            <FormControl.Feedback />
          </FormGroup>

          <FormGroup validationState={this.validationStates.confirmationNewPassword} className="label-floating">
            <ControlLabel htmlFor="confirmationNewPassword">
              { this.errors.confirmationNewPassword || 'Confirm new password' }
            </ControlLabel>
            <FormControl
              id="confirmationNewPassword"
              name="confirmationNewPassword"
              type="password"
              value={this.state.userData.confirmationNewPassword}
              onChange={this.handleOnConfirmationNewPasswordChange}
            />
            <FormControl.Feedback />
          </FormGroup>

          <FormGroup className="text-center">
            <Button
              type="submit"
              disabled={false}
              title=''
            >
            Reset password
            </Button>
          </FormGroup>
        </Form>
      </div>
    );
  }
}

NewPasswordForm.propTypes = {
  userId : PropTypes.string.isRequired,
  token : PropTypes.string.isRequired,
};
