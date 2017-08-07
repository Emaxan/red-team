import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Navbar } from 'react-bootstrap';
import PropTypes from 'prop-types';

import Routes from '../routesConstants';
import LogoImg from './images/logo.png';
import UserInfo from './UserInfo';

import './Header.scss';

export class Header extends Component {
  render() {
    return (
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
            {
              this.props.authStatus ?
                <UserInfo className="navbar__item" username="Admin" /> :
                <Link className="navbar__item" to={Routes.LogIn.path}>{Routes.LogIn.text}</Link>
            }
          </nav>
        </Navbar.Collapse>
      </Navbar>
    );
  }
}

Header.propTypes = {
  authStatus : PropTypes.bool.isRequired,
};
