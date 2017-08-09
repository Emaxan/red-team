import React from 'react';
import { Link } from 'react-router-dom';
import { Navbar } from 'react-bootstrap';
import PropTypes from 'prop-types';

import Routes from '../routesConstants';
import LogoImg from './images/logo.png';
import { default as UserInfoComponent } from './UserInfo';
import {
  userIsAuthenticated,
  userIsNotAuthenticated,
} from '../../auth/auth';

import './Header.scss';

const UserInfo = userIsAuthenticated(UserInfoComponent);
const LoginLink = userIsNotAuthenticated(() => <Link className="navbar__item" to={Routes.LogIn.path}>{Routes.LogIn.text}</Link>);


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
        <Link className="navbar__item" to={Routes.About.path}>{Routes.About.text}</Link>
        <UserInfo username={userName} />
        <LoginLink />
      </nav>
    </Navbar.Collapse>
  </Navbar>
);

Header.propTypes = {
  userName: PropTypes.string,
};

export default Header;
