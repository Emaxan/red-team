import React from 'react';
import { connect } from 'react-redux';

import { LogInForm } from './components/LogInForm';
import { logInRequest } from './actions';

function mapStateToProps(state) {
  return {
    errors : state.login.errors,
  };
}

const mapDispatchToProps = ({
  logInRequest,
});

const LogInContainer = ({ errors, logInRequest }) => (
  <div className="auth-panel">
    <LogInForm
      errors={errors}
      logInRequest={logInRequest}
    />
  </div>
);

LogInContainer.propTypes = {
  ...LogInForm.propTypes,
};

export default connect(mapStateToProps, mapDispatchToProps)(LogInContainer);
