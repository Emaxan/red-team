import React from 'react';

import { NotificationPanel } from '../../../components/NotificationPanel';

export const CheckEmailPanel = () => (
  <NotificationPanel title="Check your email!">
    <p>An email with password reset instructions has been sent to your email address.</p>
  </NotificationPanel>
);
