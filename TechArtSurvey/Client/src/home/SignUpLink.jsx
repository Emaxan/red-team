import React from 'react';
import { Link } from 'react-router-dom';

export const SignUpLink = () => (
  <div className="not-auth-wrapper">
    <Link className="not-auth-wrapper__link" to='/signup'>Please, sign up!</Link>
  </div>
);
