import React, { Component } from 'react';
import { connect } from 'react-redux';
import PropTypes from 'prop-types';

import { loginRequest, disableGreeting } from './actions';
import { LoginForm } from './components/LoginForm';
import { AuthPanel } from '../components/AuthPanel';
import { GreetingPanel } from './components/GreetingPanel';

const mapStateToProps = (state) => ({
  errors : state.login.errors,
  actionString : 'Log In',
  isGreetingEnabled : state.login.isGreetingEnabled,
  greetingMessage : state.login.greetingMessage,
});

const mapDispatchToProps = ({
  loginRequest,
  disableGreeting,
});

export class LoginContainer extends Component {
  componentWillUnmount = () => {
    this.props.disableGreeting();
  }

  render = () => {
    return (
      <AuthPanel
        actionString={this.props.actionString}
        errors={this.props.errors}
      >
        { this.props.isGreetingEnabled ? <GreetingPanel greetingMessage={this.props.greetingMessage} /> : '' }
        <LoginForm
          actionString={this.props.actionString}
          loginRequest={this.props.loginRequest}
        />
      </AuthPanel>
    );
  }
}

LoginContainer.propTypes = {
  ...AuthPanel.propTypes,
  ...LoginForm.propTypes,
  ...GreetingPanel.propTypes,
  isGreetingEnabled : PropTypes.bool.isRequired,
  disableGreeting : PropTypes.func.isRequired,
};

export default connect(mapStateToProps, mapDispatchToProps)(LoginContainer);
