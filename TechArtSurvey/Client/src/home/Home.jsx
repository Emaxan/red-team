import React from 'react';

import {userIsNotAuthenticated} from '../auth/auth';
import {SignUpLink} from './SignUpLink';
import Image from './images/main.jpg';

import './Home.scss';

const SignUp = userIsNotAuthenticated(SignUpLink);

export const Home = () => (
  <div className="home-wrapper">
    <div className="home-content">
      <h1 className="home-content__title">Welcome to ITechart Group!</h1>
      <p className="image-wrapper">
        <img className="image-wrapper__image" src={Image} alt="Main image" />
      </p>
      <p className="home-content__paragraph">
          This is our first survey web-site. Here you can find different information
          about our company and etc. After signing in as admin you may try to make
          new surveys, using existing templates or without it.
      </p>
      <SignUp/>
    </div>
  </div>
);
