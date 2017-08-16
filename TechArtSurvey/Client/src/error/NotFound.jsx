import React from 'react';

import Image from './images/404.jpg';

import './Error.scss';

export const NotFound = () =>
  <div className="error-wrapper">
    <h1 className="error-wrapper__title">Resources you are looking for are not found.</h1>
    <p className="error-wrapper__paragraph">
      <img src={Image} alt="404 not found" />
    </p>
  </div>;
