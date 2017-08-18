import React, { Component } from 'react';
import PropTypes from 'prop-types';

import { InvalidTokenMessage } from './components/InvalidTokenMessage';
import { NewPasswordForm } from './components/NewPasswordForm';
import { checkCode } from './api';

export class ResetPasswordContainer extends Component {
  constructor(props) {
    super(props);

    this.state = {
      isTokenValid : false,
    };
  }

  componentWillMount() {
    checkCode(this.props.match.params.id, this.props.match.params.code)
      .then(data => {
        if (data.statusCode === 200) {
          this.setState({... this.state, isTokenValid : true});
        }
      });
  }

  render() {
    return (
      <div>
        <h1>Forgot password page</h1>
        {this.state.isTokenValid ? <NewPasswordForm id={this.props.match.params.id} code={this.props.match.params.code} /> : <InvalidTokenMessage />}
      </div>
    );
  }
}

ResetPasswordContainer.propTypes = {
  match : PropTypes.object.isRequired,
};
