import React from 'react';
import PropTypes from 'prop-types';

import { PanelWrapper } from '../../../components/PanelWrapper';

export const CheckEmailPanel = ({ email }) => (
  <PanelWrapper title="Check your email!">
    <p>We were sent message at {email}. Please, check out!</p>
  </PanelWrapper>
);

CheckEmailPanel.propTypes = {
  email : PropTypes.string.isRequired,
};
