import React from 'react';
import { Link } from 'react-router-dom';
import { Button } from 'react-bootstrap';

import Routes from '../../routes';

import './Header.scss';

const HeaderLink = () => (
  <Button className="navbar__item-wrapper">
    <Link className="navbar__item react-bootstrap-link" to={Routes.Login.path}>{Routes.Login.text}</Link>
  </Button>
);

export default HeaderLink;
