import React from 'react';
import { connect } from 'react-redux';

import { AuthPanel } from '../components/AuthPanel';
import { ForgotPasswordForm } from './components/ForgotPasswordForm';
import { checkEmailExistenceRequest } from '../actions';

const mapStateToProps = (state) => ({
  errors : state.auth.errors,
  actionString : 'Forgot password? Do not worry! Enter your e-mail below:',
  isEmailRegistered : state.auth.isEmailRegistered,
});

const mapDispatchToProps = {
  checkEmailExistenceRequest,
};

const ForgotPasswordContainer = ({ errors, actionString, isEmailRegistered, checkEmailExistenceRequest }) => (
  <AuthPanel
    actionString={actionString}
    errors={errors}
  >
    <ForgotPasswordForm
      checkEmailExistenceRequest={checkEmailExistenceRequest}
      isEmailRegistered={isEmailRegistered}
    />
  </AuthPanel>
);

ForgotPasswordContainer.propTypes = {
  ...AuthPanel.propTypes,
  ...ForgotPasswordForm.propTypes,
};

export default connect(mapStateToProps, mapDispatchToProps)(ForgotPasswordContainer);
