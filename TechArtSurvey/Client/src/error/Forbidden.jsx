import React from 'react';

import Image from './images/403.jpg';

import './Error.scss';

export const Forbidden = () =>
  <div className="error-wrapper">
    <div className="error-image-wrapper">
      <img className="error-image-wrapper__image" src={Image} alt="403 forbidden" />
    </div>
  </div>;
