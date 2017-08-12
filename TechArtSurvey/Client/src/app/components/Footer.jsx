import React from 'react';

import './Footer.scss';

const year = (new Date()).getFullYear();

const Footer = () => (
  <footer className="footer">
    Copyright <sup>&copy;</sup> {year} iTechArt
  </footer>
);

export default Footer;
