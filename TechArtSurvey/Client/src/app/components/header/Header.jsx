import React from 'react';
import { Link } from 'react-router-dom';
import { Button, Navbar } from 'react-bootstrap';
import PropTypes from 'prop-types';

import Routes from '../../routes';
import LogoImg from '.././images/logo.png';
import { default as UserInfoComponent } from './UserInfo';
import HeaderLink from './HeaderLink';
import {
  userIsAuthenticated,
  userIsNotAuthenticated,
} from '../../../auth/authWrappers';

import './Header.scss';

const UserInfo = userIsAuthenticated(UserInfoComponent);
const LoginLink = userIsNotAuthenticated(HeaderLink);

const Header = ({ userName, email }) => (
  <header>
    <Navbar fluid className="navbar-wrapper">
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
  </header>
);

Header.propTypes = {
  userName : PropTypes.string.isRequired,
  email : PropTypes.string.isRequired,
};

export default Header;
