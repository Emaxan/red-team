import React, { Component } from 'react';
import { connect } from 'react-redux';
import PropTypes from 'prop-types';

import { AuthPanel } from '../components/AuthPanel';
import { InvalidTokenMessage } from './components/InvalidTokenMessage';
import { NewPasswordForm } from './components/NewPasswordForm';
import { checkPasswordResetTokenRequest } from './actions';

const mapStateToProps = (state) => ({
  errors : state.auth.errors,
  actionString : 'Reset password',
  tokenValid : state.resetPassword.tokenValid,
});

const mapDispatchToProps = () => ({
  checkPasswordResetTokenRequest,
});

export class ResetPasswordContainer extends Component {
  constructor(props) {
    super(props);
  }

  componentWillMount() {
    console.log('componentWillMount');
    this.props.checkPasswordResetTokenRequest(
      this.props.match.params.userId,
      this.props.match.params.token,
    );
    console.log('componentWillMount: end');
  }

  render() {
    console.log('render');
    if (!this.props.tokenValid) {
      return <InvalidTokenMessage />;
    }

    return (
      <AuthPanel
        actionString={this.props.actionString}
        errors={this.props.errors}
      >
        <NewPasswordForm
          userId={this.props.match.params.userId}
          token={this.props.match.params.token}
        />
      </AuthPanel>
    );
  }
}

ResetPasswordContainer.propTypes = {
  ...AuthPanel.propTypes,
  match : PropTypes.object.isRequired,
  tokenValid : PropTypes.bool.isRequired,
  checkPasswordResetTokenRequest : PropTypes.func.isRequired,
};

export default connect(mapStateToProps, mapDispatchToProps)(ResetPasswordContainer);
