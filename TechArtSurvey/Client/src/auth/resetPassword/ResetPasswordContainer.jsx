import React, { Component } from 'react';
import { connect } from 'react-redux';
import PropTypes from 'prop-types';

import { AuthPanel } from '../components/AuthPanel';
import { InvalidTokenPanel } from './components/InvalidTokenPanel';
import { ResetPasswordForm } from './components/ResetPasswordForm';
import {
  checkPasswordResetTokenRequest,
  resetPasswordRequest,
} from './actions';
import { Spinner } from '../../components/Spinner';

const mapStateToProps = (state) => ({
  errors : state.auth.errors,
  actionString : 'Reset password',
  isFetching : state.resetPassword.isFetching,
  tokenValid : state.resetPassword.tokenValid,
});

const mapDispatchToProps = {
  checkPasswordResetTokenRequest,
  resetPasswordRequest,
};

export class ResetPasswordContainer extends Component {
  constructor(props) {
    super(props);
  }

  componentWillMount() {
    this.props.checkPasswordResetTokenRequest(
      this.props.match.params.userId,
      this.props.match.params.token,
    );
  }

  render() {
    if (this.props.isFetching) {
      return <Spinner />;
    }

    if (!this.props.tokenValid) {
      return <InvalidTokenPanel />;
    }

    return (
      <AuthPanel
        actionString={this.props.actionString}
        errors={this.props.errors}
      >
        <ResetPasswordForm
          userId={this.props.match.params.userId}
          token={this.props.match.params.token}
          resetPasswordRequest={this.props.resetPasswordRequest}
        />
      </AuthPanel>
    );
  }
}

ResetPasswordContainer.propTypes = {
  ...AuthPanel.propTypes,
  match : PropTypes.object.isRequired,
  isFetching : PropTypes.bool.isRequired,
  tokenValid : PropTypes.bool.isRequired,
  checkPasswordResetTokenRequest : PropTypes.func.isRequired,
};

export default connect(mapStateToProps, mapDispatchToProps)(ResetPasswordContainer);
