import React from 'react';
import { Panel } from 'react-bootstrap';
import PropTypes from 'prop-types';

import './PanelWrapper.scss';

export const PanelWrapper = ({ title, children }) => (
  <div className="panel-wrapper">
    <Panel>
      <h1 className="panel-wrapper__title">{title}</h1>
      <div className="panel-wrapper__content">
        {children}
      </div>
    </Panel>
  </div>
);

PanelWrapper.propTypes = {
  children : PropTypes.any.isRequired,
  title : PropTypes.string.isRequired,
};
