import React from 'react';
import { Image } from 'react-bootstrap';

import Img from './images/people.png';

import './BasicInfo.scss';

const BasicInfo = () => (
  <div className="basic-info">
    <Image className="basic-info__img" src={Img} />
  </div>
);

export default BasicInfo;