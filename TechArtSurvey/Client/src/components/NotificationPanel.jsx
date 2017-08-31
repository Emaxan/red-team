import React from 'react';
import { Panel } from 'react-bootstrap';
import PropTypes from 'prop-types';

import './NotificationPanel.scss';

export const NotificationPanel = ({ title, children }) => (
  <div className="notification-panel">
    <Panel>
      <h1 className="notification-panel__title">{title}</h1>
      <div className="notification-panel__content">
        {children}
      </div>
    </Panel>
  </div>
);

NotificationPanel.propTypes = {
  children : PropTypes.node.isRequired,
  title : PropTypes.string.isRequired,
};
