import React, { Component } from 'react';
import { connect } from 'react-redux';

import { signupRequest } from './actions';
import { SignupForm } from './components/SignupForm';

import './SignupContainer.scss';

const mapStateToProps = (state) => ({
  errors : state.signup.errors,
});

const mapDispatchToProps = {
  signupRequest,
};

export class SignupContainer extends Component {
  render() {
    return (
      <div className="auth-panel">
        <SignupForm
          errors={this.props.errors}
          signupRequest={this.props.signupRequest}
        />
      </div>
    );
  }
}

SignupContainer.propTypes = {
  ...SignupForm.propTypes,
};

export default connect(mapStateToProps, mapDispatchToProps)(SignupContainer);
