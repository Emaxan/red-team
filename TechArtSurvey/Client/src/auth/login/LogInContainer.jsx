import React, { Component } from 'react';
import { connect } from 'react-redux';

import { LogInForm } from './components/LogInForm';
import { userLogInRequest } from './actions';

function mapStateToProps(state) {
  return {
    errors : state.login.errors,
  };
}

const mapDispatchToProps = (dispatch) => ({
  logInRequest : (data) => {
    dispatch(userLogInRequest(data));
  },
});

export class LogInContainer extends Component {
  render() {
    return (
      <div className="auth-panel">
        <LogInForm
          errors={this.props.errors}
          logInRequest={this.props.logInRequest}
        />
      </div>
    );
  }
}

LogInContainer.propTypes = {
  ...LogInForm.propTypes,
};

export default connect(mapStateToProps, mapDispatchToProps)(LogInContainer);
