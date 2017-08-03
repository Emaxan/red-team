import React, { Component } from 'react';
import { Link } from 'react-router-dom';

import './Sidebar.scss';
import Routes from '../routesConstants';
import Roles from '../roles';

export class Sidebar extends Component {
  render() {
    const items = [];
    for (const route in Routes) {
      if (Routes[route].access <= Roles.ADMIN) {
        items.push(Routes[route]);
      }
    }

    return (
      <aside className="menu">
        {
          items.map((item, i) => (
            <Link key={i} to={item.path} className="menu__item">{item.text}</Link>
          ))
        }
      </aside>
    );
  }
}
