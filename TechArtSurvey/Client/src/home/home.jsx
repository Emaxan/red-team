import React from 'react';

import {userIsNotAuthenticated} from '../auth/auth';
import {NotAuth} from './NotAuth';
import Image from './images/main.jpg';

import './Home.scss';

const NotAuthMessage = userIsNotAuthenticated(NotAuth);

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
      <NotAuthMessage/>
    </div>
  </div>
);
