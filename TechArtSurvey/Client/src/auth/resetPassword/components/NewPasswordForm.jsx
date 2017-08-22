import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { Form, FormGroup, FormControl, ControlLabel, Button } from 'react-bootstrap';

import {
  validatePassword,
  validateConfirmationPassword,
} from '../../../utils/validation/userValidation.js';

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

    this.props.resetPasswordRequest(
      this.props.userId,
      this.props.token,
      this.state.userData.newPassword,
    );
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
    this.setValidationState('confirmationNewPassword', validateConfirmationPassword(password, confirmationPassword));
  }

  handleOnNewPasswordChange = (event) => {
    const validationInfo = validatePassword(event.target.value);
    this.setValidationState('newPassword', validationInfo);

    if (validationInfo.isValid) {
      this.makeConfirmationPasswordValidation(event.target.value,
        this.state.userData.confirmationNewPassword);
    }

    this.setState({ userData : { ...this.state.userData, newPassword : event.target.value }});
  }

  handleOnConfirmationNewPasswordChange = (event) => {
    this.makeConfirmationPasswordValidation(this.state.userData.newPassword, event.target.value);
    this.setState({ userData : { ...this.state.userData, confirmationNewPassword : event.target.value}});
  }

  isInputValid() {
    return Object.values(this.errors)
      .every((err) => err === null);
  }

  render() {
    const formValid = this.isInputValid();

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
              disabled={!formValid}
              title=
                {
                  formValid ?
                    '' :
                    'All fields must be filled'
                }
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
  resetPasswordRequest : PropTypes.func.isRequired,
};
