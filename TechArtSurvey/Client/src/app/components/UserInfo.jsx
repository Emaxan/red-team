import React from 'react';
import { Image, MenuItem, Dropdown } from 'react-bootstrap';
import { connect } from 'react-redux';

import {
  userIsAuthenticated,
} from '../../auth/auth';
import UserImg from './images/user-icon.png';
import { logOutRequest } from '../../auth/login/actions';

import './UserInfo.scss';

const LogoutLink = userIsAuthenticated(({ logout }) => <span onClick={() => logout()}>Logout</span>);

const UserInfo = ({ username, logOutRequest }) => (
  <div className='navbar__item'>
    {/* DROPDOWN MENU STYLE WILL BE FIXED */}
    <Dropdown id="userInfoDropdown">
      <Dropdown.Toggle>
        <Image src={UserImg} className="navbar__user-img" rounded />
        Hello, {username}!
      </Dropdown.Toggle>
      <Dropdown.Menu>
        <MenuItem>Something</MenuItem>
        <MenuItem divider />
        <MenuItem>
          <LogoutLink logout={logOutRequest} />
        </MenuItem>
      </Dropdown.Menu>
    </Dropdown>
  </div>
);

UserInfo.propTypes = {
  ...UserInfo.propTypes,
};

const mapDispatchToProps = ({
  logOutRequest,
});

export default connect(null, mapDispatchToProps)(UserInfo);
