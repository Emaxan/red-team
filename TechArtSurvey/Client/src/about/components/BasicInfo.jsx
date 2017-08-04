import React, { Component } from 'react';
import { Image } from 'react-bootstrap';

import Img from './images/people.jpg';

import './BasicInfo.scss';

export class BasicInfo extends Component {
  render() {
    return (
      <div className="basic-info">
        <h1 className="basic-info__logo">iTechArt</h1>
        <Image className="basic-info__img" src={Img} />
      </div>
    );
  }
}
