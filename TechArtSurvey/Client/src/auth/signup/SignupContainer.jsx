import React from 'react';
import { connect } from 'react-redux';

import { signupRequest } from './actions';
import { SignupForm } from './components/SignupForm';

import './SignupContainer.scss';

const mapStateToProps = (state) => ({
  errors : state.signup.errors,
});

const mapDispatchToProps = {
  signupRequest,
};

const SignupContainer = ({ errors, signupRequest }) => (
  <div className="auth-panel">
    <SignupForm
      errors={errors}
      signupRequest={signupRequest}
    />
  </div>
);

SignupContainer.propTypes = {
  ...SignupForm.propTypes,
};

export default connect(mapStateToProps, mapDispatchToProps)(SignupContainer);
