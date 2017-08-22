import React, { Component } from 'react';
import { connect } from 'react-redux';
import PropTypes from 'prop-types';

import { loginRequest, disableGreeting } from './actions';
import { LoginForm } from './components/LoginForm';
import { AuthPanel } from '../AuthPanel';
import GreetingPanel from './components/GreetingPanel';

import './LoginContainer.scss';

const mapStateToProps = (state) => ({
  errors : state.login.errors,
  actionString : 'Log In',
  isGreetingEnabled : state.login.isGreetingEnabled,
});

const mapDispatchToProps = ({
  loginRequest,
  disableGreeting,
});

export class LoginContainer extends Component {
  constructor(props) {
    super(props);
  }

  componentWillUnmount() {
    this.props.disableGreeting();
  }

  render() {
    return (
      <div className="login-container">
        { this.props.isGreetingEnabled ? <GreetingPanel /> : '' }
        <AuthPanel
          actionString={this.props.actionString}
          errors={this.props.errors}
        >
          <LoginForm
            actionString={this.props.actionString}
            loginRequest={this.props.loginRequest}
          />
        </AuthPanel>
      </div>
    );
  }
}

LoginContainer.propTypes = {
  ...AuthPanel.propTypes,
  ...LoginForm.propTypes,
  isGreetingEnabled : PropTypes.bool.isRequired,
  disableGreeting : PropTypes.func.isRequired,
};

export default connect(mapStateToProps, mapDispatchToProps)(LoginContainer);
