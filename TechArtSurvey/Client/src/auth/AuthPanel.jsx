import React, { Component } from 'react';
import PropTypes from 'prop-types';
import ImmutablePropTypes from 'react-immutable-proptypes';
import { FormGroup, FormControl, Panel } from 'react-bootstrap';

import './AuthPanel.scss';

export class AuthPanel extends Component {
  render() {
    return(
      <div className="auth-panel">
        <Panel className="col-md-6 col-md-offset-3">

          <h2 className="auth__title">{this.props.actionString}</h2>

          <FormGroup>
            {
              this.props.errors.map((error, i) => (
                <FormControl.Static key={i} className="text-danger">
                  <strong>{error}</strong>
                </FormControl.Static>
              ))
            }
          </FormGroup>

          {this.props.children}

        </Panel>
      </div>
    );
  }
}

AuthPanel.propTypes = {
  errors : ImmutablePropTypes.list.isRequired,
  actionString : PropTypes.string.isRequired,
  children : PropTypes.object,
};
