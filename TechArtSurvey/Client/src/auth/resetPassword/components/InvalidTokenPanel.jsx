import React from 'react';

import { PanelWrapper } from '../../../components/PanelWrapper';

export const InvalidTokenPanel = () => (
  <PanelWrapper>
    <p>1. Check your internet connection.</p>
    <p>2. Make sure that you followed correct link.</p>
    <p>3. If all above is not about you - sorry, but your link lifetime was expired and you should repeat your request.</p>
  </PanelWrapper>
);
