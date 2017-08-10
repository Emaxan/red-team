import React from 'react';
import { connect } from 'react-redux';

import { logInRequest } from './actions';
import { LogInForm } from './components/LogInForm';
import { AuthPanel } from '../AuthPanel';

const mapStateToProps = (state) => ({
  errors : state.login.errors,
  actionString : 'Log In',
});

const mapDispatchToProps = ({
  logInRequest,
});

const LogInContainer = ({ errors, actionString, logInRequest }) => (
  <AuthPanel
    actionString={actionString}
    errors={errors}
  >
    <LogInForm
      actionString={actionString}
      logInRequest={logInRequest}
    />
  </AuthPanel>
);

LogInContainer.propTypes = {
  ...AuthPanel.propTypes,
  ...LogInForm.propTypes,
};

export default connect(mapStateToProps, mapDispatchToProps)(LogInContainer);
