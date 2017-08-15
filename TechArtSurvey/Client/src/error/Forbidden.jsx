import React from 'react';

import Image from './images/403.jpg';

export const Forbidden = () =>
  <div className="error-wrapper">
    <h1>Your request was forbidden.</h1>
    <img src={Image} alt="403 forbidden" />
  </div>;
