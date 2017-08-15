import React from 'react';
import { Link } from 'react-router-dom';
import { Button } from 'react-bootstrap';
import PropTypes from 'prop-types';

import './Sidebar.scss';

const Sidebar = ({ menuItems, className }) => (
  <aside className={'menu ' + (className || '')}>
    {
      menuItems.map((item, i) => (
        <Button key={i} className="menu__item-wrapper">
          <span className={item.icon || 'glyphicon glyphicon-asterisk'}/>
          <Link to={item.path} className="menu__item react-bootstrap-link">{item.text}</Link>
        </Button>
      ))
    }
  </aside>
);

Sidebar.propTypes = {
  menuItems : PropTypes.array.isRequired,
  className : PropTypes.string,
};

export default Sidebar;
