import React from 'react';
import { connect } from 'react-redux';

import { signupRequest, checkEmailExistenceRequest } from './actions';
import { SignupForm } from './components/SignupForm';

import './SignupContainer.scss';

const mapStateToProps = (state) => ({
  errors : state.signup.errors,
});

const mapDispatchToProps = {
  signupRequest,
  checkEmailExistenceRequest,
};

const SignupContainer = ({ errors, signupRequest }) => (
  <div className="auth-panel">
    <SignupForm
      errors={errors}
      signupRequest={signupRequest}
      checkEmailExistenceRequest={this.props.checkEmailExistenceRequest}
    />
  </div>
);

SignupContainer.propTypes = {
  ...SignupForm.propTypes,
  checkEmailExistenceRequest : PropTypes.func.isRequired,
};

export default connect(mapStateToProps, mapDispatchToProps)(SignupContainer);
