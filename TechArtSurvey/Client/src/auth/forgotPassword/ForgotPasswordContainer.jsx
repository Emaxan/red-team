import React, { Component } from 'react';
import { connect } from 'react-redux';
import PropTypes from 'prop-types';

import { AuthPanel } from '../components/AuthPanel';
import { ForgotPasswordForm } from './components/ForgotPasswordForm';
import { checkEmailExistenceRequest } from '../actions';
import { forgotPasswordRequest } from './actions';

const mapStateToProps = (state) => ({
  errors : state.auth.errors,
  actionString : 'Forgot password? Do not worry! Enter your e-mail below:',
  isEmailRegistered : state.auth.isEmailRegistered,
  messageWasSent : state.forgotPassword.messageWasSent,
});

const mapDispatchToProps = {
  checkEmailExistenceRequest,
  forgotPasswordRequest,
};

export class ForgotPasswordContainer extends Component {
  constructor(props) {
    super(props);
  }

  render() {
    if (this.props.messageWasSent) {
      return <h1>Check your e-mail</h1>;
    }

    return (
      <AuthPanel
        actionString={this.props.actionString}
        errors={this.props.errors}
      >
        <ForgotPasswordForm
          checkEmailExistenceRequest={this.props.checkEmailExistenceRequest}
          forgotPasswordRequest={this.props.forgotPasswordRequest}
          isEmailRegistered={this.props.isEmailRegistered}
        />
      </AuthPanel>
    );
  }
}

ForgotPasswordContainer.propTypes = {
  ...AuthPanel.propTypes,
  ...ForgotPasswordForm.propTypes,
  messageWasSent : PropTypes.bool.isRequired,
};

export default connect(mapStateToProps, mapDispatchToProps)(ForgotPasswordContainer);
