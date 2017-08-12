import React from 'react';
import { Link } from 'react-router-dom';
import PropTypes from 'prop-types';

import './Sidebar.scss';

const Sidebar = ({ menuItems, className }) => (
  <aside className={'menu ' + className}>
    {
      menuItems.map((item, i) => (
        <Link key={i} to={item.path} className="menu__item">{item.text}</Link>
      ))
    }
  </aside>
);

Sidebar.propTypes = {
  menuItems : PropTypes.array.isRequired,
  className : PropTypes.string,
};

export default Sidebar;
