import React from 'react';
import { Link } from 'react-router-dom';
import { Button, Navbar } from 'react-bootstrap';
import PropTypes from 'prop-types';

import Routes from '../routes';
import LogoImg from './images/logo.png';
import { default as UserInfoComponent } from './UserInfo';
import {
  userIsAuthenticated,
  userIsNotAuthenticated,
} from '../../auth/auth';

import './Header.scss';

const UserInfo = userIsAuthenticated(UserInfoComponent);
const LoginLink = userIsNotAuthenticated(() => {
  return (
    <Button className="navbar__item-wrapper">
      <Link className="navbar__item" to={Routes.Login.path}>{Routes.Login.text}</Link>
    </Button>
  );
});

const Header = ({ userName }) => (
  <Navbar>
    <Navbar.Header>
      <Navbar.Brand>
        <Link to={Routes.Main.path}>
          <img src={LogoImg} alt="iTechArt logo" />
        </Link>
      </Navbar.Brand>
      <Navbar.Toggle />
    </Navbar.Header>
    <Navbar.Collapse>
      <nav>
        <Button className="navbar__item-wrapper">
          <Link className="navbar__item" to={Routes.About.path}>{Routes.About.text}</Link>
        </Button>
        <LoginLink />
        <UserInfo username={userName} />
      </nav>
    </Navbar.Collapse>
  </Navbar>
);

Header.propTypes = {
  userName : PropTypes.string.isRequired,
};

export default Header;
