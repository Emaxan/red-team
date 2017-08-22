import React from 'react';
import { Panel } from 'react-bootstrap';

import './InvalidTokenPanel.scss';

export const InvalidTokenPanel = () => (
  <div className="invalid-token-message">
    <Panel>
      <h1 className="invalid-token-message__title">Oops! Some problems has occurred...</h1>
      <div className="invalid-token-message__content">
        <p>1. Check your internet connection.</p>
        <p>2. Make sure that you followed correct link.</p>
        <p>3. If all above is not about you - sorry, but your link lifetime was expired and you should repeat your request.</p>
      </div>
    </Panel>
  </div>
);
