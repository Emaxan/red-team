import React from 'react';
import { Link } from 'react-router-dom';
import PropTypes from 'prop-types';

import './Sidebar.scss';

const Sidebar = ({ menuItems }) => (
  <aside className="menu">
    {
      menuItems.map((item, i) => (
        <Link key={i} to={item.path} className="menu__item">{item.text}</Link>
      ))
    }
  </aside>
);

Sidebar.propTypes = {
  menuItems : PropTypes.array.isRequired,
};

export default Sidebar;
