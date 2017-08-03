import React from 'react';
import PropTypes from 'prop-types';
import { Image } from 'react-bootstrap';

import UserImg from './images/user-icon.png';

import './UserInfo.scss';

const UserInfo = ({ username }) => (
  <div className="user-info">
    <Image src={UserImg} className="user-info__img" rounded />
    Hello, {username}!
    <span>&#9207;</span>
  </div>
);

UserInfo.propTypes = {
  username : PropTypes.string.isRequired,
};

export default UserInfo;
