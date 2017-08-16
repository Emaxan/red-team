import React from 'react';
import { connect } from 'react-redux';

import { signUpRequest, checkEmailExistenceRequest } from './actions';
import { SignUpForm } from './components/SignUpForm';
import { AuthPanel } from '../AuthPanel';

const mapStateToProps = (state) => ({
  errors : state.signUp.errors,
  actionString : 'Sign Up',
});

const mapDispatchToProps = {
  signUpRequest,
  checkEmailExistenceRequest,
};

const SignUpContainer = ({ errors, actionString, signUpRequest, checkEmailExistenceRequest }) => (
  <AuthPanel
    actionString={actionString}
    errors={errors}
  >
    <SignUpForm
      errors={errors}
      actionString={actionString}
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
