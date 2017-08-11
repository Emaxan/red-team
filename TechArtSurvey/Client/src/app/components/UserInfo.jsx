import React from 'react';
import { Image, MenuItem, Dropdown } from 'react-bootstrap';
import { connect } from 'react-redux';

import {
  userIsAuthenticated,
} from '../../auth/auth';
import UserImg from './images/user-icon.png';
import { logoutRequest } from '../../auth/login/actions';

import './UserInfo.scss';

const LogoutLink = userIsAuthenticated(({ logout }) => <span onClick={() => logout()}>Logout</span>);

const UserInfo = ({ username, logoutRequest }) => (
  <div className='navbar__item'>
    <Dropdown id="userInfoDropdown">
      <Dropdown.Toggle className="navbar__item-wrapper">
        <Image src={UserImg} className="navbar__user-img" rounded />
        {username}
      </Dropdown.Toggle>
      <Dropdown.Menu>
        <MenuItem>
          <LogoutLink logout={logoutRequest} />
        </MenuItem>
      </Dropdown.Menu>
    </Dropdown>
  </div>
);

UserInfo.propTypes = {
  ...UserInfo.propTypes,
};

const mapDispatchToProps = ({
  logoutRequest,
});

export default connect(null, mapDispatchToProps)(UserInfo);
