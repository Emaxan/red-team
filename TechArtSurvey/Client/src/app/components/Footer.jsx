import React from 'react';

import './Footer.scss';

const year = (new Date()).getFullYear();

const Footer = () => (
  <footer className="footer">
    <p className="footer__paragraph">Copyright <sup>&copy;</sup> {year} iTechArt</p>
  </footer>
);

export default Footer;
