import React from 'react';
import PropTypes from 'prop-types';

import './GreetingPanel.scss';

export const GreetingPanel = ({ greetingMessage }) => (
  <div className="greeting-panel">
    <h1>{greetingMessage}</h1>
  </div>
);

GreetingPanel.propTypes = {
  greetingMessage : PropTypes.string.isRequired,
};
