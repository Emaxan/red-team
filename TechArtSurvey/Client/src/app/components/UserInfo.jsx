import React from 'react';
import PropTypes from 'prop-types';
import { Image } from 'react-bootstrap';

import UserImg from './images/user-icon.png';

import './UserInfo.scss';

const UserInfo = ({ className, username }) => (
  <div className={'user-info ' + className}>
    <Image src={UserImg} className="user-info__img" rounded />
    Hello, {username}!
    <span>&#9207;</span>
  </div>
);

UserInfo.propTypes = {
  username : PropTypes.string.isRequired,
  className : PropTypes.string,
};

export default UserInfo;
