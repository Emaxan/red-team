import React from 'react';
import { connect } from 'react-redux';

import { signUpRequest } from './actions';
import { checkEmailExistenceRequest } from '../actions';
import { SignUpForm } from './components/SignUpForm';
import { AuthPanel } from '../components/AuthPanel';

const mapStateToProps = (state) => ({
  errors : state.auth.errors.concat(state.signUp.errors),
  actionString : 'Sign Up',
  isEmailRegistered : state.auth.isEmailRegistered,
});

const mapDispatchToProps = {
  signUpRequest,
  checkEmailExistenceRequest,
};

const SignUpContainer = ({ errors, actionString, isEmailRegistered, signUpRequest, checkEmailExistenceRequest }) => (
  <AuthPanel
    actionString={actionString}
    errors={errors}
  >
    <SignUpForm
      actionString={actionString}
      isEmailRegistered={isEmailRegistered}
      signUpRequest={signUpRequest}
      checkEmailExistenceRequest={checkEmailExistenceRequest}
    />
  </AuthPanel>
);

SignUpContainer.propTypes = {
  ...AuthPanel.propTypes,
  ...SignUpForm.propTypes,
};

export default connect(mapStateToProps, mapDispatchToProps)(SignUpContainer);
