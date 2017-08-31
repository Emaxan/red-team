import React from 'react';
import { ClipLoader } from 'react-spinners';

import './Spinner.scss';

export const Spinner = () => (
  <div className="spinner-wrapper">
    <ClipLoader
      loading={true}
      size={100}
    />
  </div>
);
