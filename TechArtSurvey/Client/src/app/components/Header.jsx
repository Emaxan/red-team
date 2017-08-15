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
      <Link className="navbar__item react-bootstrap-link" to={Routes.Login.path}>{Routes.Login.text}</Link>
    </Button>
  );
});

const Header = ({ userName, email }) => (
  <Navbar fluid>
    <Navbar.Header>
      <Navbar.Brand className="navbar-brand">
        <Link className="navbar-brand__link react-bootstrap-link" to={Routes.Main.path}>
          <img className="navbar-brand__image" src={LogoImg} alt="iTechArt logo" />
        </Link>
      </Navbar.Brand>
      <Navbar.Toggle />
    </Navbar.Header>
    <Navbar.Collapse className="react-bootstrap-navbar-collapse">
      <nav>
        <Button className="navbar__item-wrapper">
          <Link className="navbar__item" to={Routes.About.path}>{Routes.About.text}</Link>
        </Button>
        <LoginLink />
        <UserInfo username={userName} email={email} />
      </nav>
    </Navbar.Collapse>
  </Navbar>
);

Header.propTypes = {
  userName : PropTypes.string.isRequired,
  email : PropTypes.string.isRequired,
};

export default Header;
