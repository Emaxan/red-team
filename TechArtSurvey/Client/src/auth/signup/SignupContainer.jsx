import React, { Component } from 'react';
import { connect } from 'react-redux';
import { PropTypes } from 'prop-types';

import { userSignupRequest } from './actions';
import { SignupForm } from './components/SignupForm';

const mapStateToProps = (state) => ({
  errors : state.signup.errors,
});

const mapDispatchToProps = (dispatch) => ({
  signupRequest : (data) => {
    dispatch(userSignupRequest(data));
  },
});

export class SignupContainer extends Component {
  render() {
    return (
      <div>
        <main className="main">
          <SignupForm
            errors={this.props.errors}
            signupRequest={this.props.signupRequest}
          />
        </main>
      </div>
    );
  }
}

SignupContainer.propTypes = {
  errors : PropTypes.object.isRequired, // Use immutable-prop-types
  signupRequest : PropTypes.func.isRequired,
};

export default connect(mapStateToProps, mapDispatchToProps)(SignupContainer);
