import React from 'react';
import { MenuItem, Dropdown } from 'react-bootstrap';
import { connect } from 'react-redux';
import Gravatar from 'react-gravatar';

import {
  userIsAuthenticated,
} from '../../../auth/auth';
import { logoutRequest } from '../../../auth/login/actions';

import './UserInfo.scss';

const LogoutLink = userIsAuthenticated(({ logout }) => <div onClick={() => logout()}>Logout</div>);

const UserInfo = ({ username, email, logoutRequest }) => (
  <div className='navbar__item'>
    <Dropdown id="userInfoDropdown">
      <Dropdown.Toggle className="navbar__item-wrapper">
        <Gravatar
          email={email}
          default="mm"
          size={60}
          className="navbar__user-img"
        />
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
