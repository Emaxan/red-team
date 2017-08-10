import React from 'react';
import { connect } from 'react-redux';

import { signupRequest, checkEmailExistenceRequest } from './actions';
import { SignupForm } from './components/SignupForm';
import { AuthPanel } from '../AuthPanel';

const mapStateToProps = (state) => ({
  errors : state.signup.errors,
  actionString : 'Sign Up',
});

const mapDispatchToProps = {
  signupRequest,
  checkEmailExistenceRequest,
};

const SignupContainer = ({ errors, actionString, signupRequest, checkEmailExistenceRequest }) => (
  <AuthPanel
    actionString={actionString}
    errors={errors}
  >
    <SignupForm
      errors={errors}
      actionString={actionString}
      signupRequest={signupRequest}
      checkEmailExistenceRequest={checkEmailExistenceRequest}
    />
  </AuthPanel>
);

SignupContainer.propTypes = {
  ...AuthPanel.propTypes,
  ...SignupForm.propTypes,
};

export default connect(mapStateToProps, mapDispatchToProps)(SignupContainer);
