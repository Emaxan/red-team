import React from 'react';
import { connect } from 'react-redux';

import { loginRequest } from './actions';
import { LoginForm } from './components/LoginForm';
import { AuthPanel } from '../AuthPanel';

const mapStateToProps = (state) => ({
  errors : state.login.errors,
  actionString : 'Log In',
});

const mapDispatchToProps = ({
  loginRequest,
});

const LoginContainer = ({ errors, actionString, loginRequest }) => (
  <AuthPanel
    actionString={actionString}
    errors={errors}
  >
    <LoginForm
      actionString={actionString}
      loginRequest={loginRequest}
    />
  </AuthPanel>
);

LoginContainer.propTypes = {
  ...AuthPanel.propTypes,
  ...LoginForm.propTypes,
};

export default connect(mapStateToProps, mapDispatchToProps)(LoginContainer);
