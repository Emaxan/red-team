import React from 'react';

import Image from './images/404.jpg';

export const NotFound = () =>
  <div className="error-wrapper">
    <h1>Resources you are looking for are not found.</h1>
    <img src={Image} alt="404 not found" />
  </div>;
