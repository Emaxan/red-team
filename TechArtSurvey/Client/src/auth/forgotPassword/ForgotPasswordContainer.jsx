import React, { Component } from 'react';
import { connect } from 'react-redux';
import PropTypes from 'prop-types';

import { AuthPanel } from '../components/AuthPanel';
import { CheckEmailPanel } from './components/CheckEmailPanel';
import { ForgotPasswordForm } from './components/ForgotPasswordForm';
import { checkEmailExistenceRequest } from '../actions';
import { forgotPasswordRequest } from './actions';
import { Spinner } from '../../components/Spinner';

const mapStateToProps = (state) => ({
  errors : state.auth.errors,
  actionString : 'Forgot password? Do not worry! Enter your e-mail below',
  isEmailRegistered : state.auth.isEmailRegistered,
  isFetching : state.forgotPassword.isFetching,
  messageWasSent : state.forgotPassword.messageWasSent,
  email : state.forgotPassword.email,
});

const mapDispatchToProps = {
  checkEmailExistenceRequest,
  forgotPasswordRequest,
};

export class ForgotPasswordContainer extends Component {
  constructor(props) {
    super(props);
  }

  render = () => {
    if (this.props.isFetching) {
      return <Spinner />;
    }

    if (this.props.messageWasSent) {
      return <CheckEmailPanel email={this.props.email} />;
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
  ...CheckEmailPanel.propTypes,
  ...ForgotPasswordForm.propTypes,
  isFetching : PropTypes.bool.isRequired,
  messageWasSent : PropTypes.bool.isRequired,
};

export default connect(mapStateToProps, mapDispatchToProps)(ForgotPasswordContainer);
