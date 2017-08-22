import React from 'react';
import { Panel } from 'react-bootstrap';
import PropTypes from 'prop-types';

import './CheckEmailPanel.scss';

export const CheckEmailPanel = ({ email }) => (
  <div className="check-email-panel">
    <Panel>
      <h1 className="check-email-panel__title">Check your email!</h1>
      <div className="check-email-panel__content">
        <p>We were sent message at {email}. Please, check out!</p>
      </div>
    </Panel>
  </div>
);

CheckEmailPanel.propTypes = {
  email : PropTypes.string.isRequired,
};
