import React, { Component } from 'react';

import './Footer.scss';

export class Footer extends Component {
  constructor() {
    super();
    this.year = (new Date())
      .getFullYear();
  }

  render() {
    return (
      <footer className="footer">
        <p className="footer__paragraph">Copyright <sup>&copy;</sup> {this.year} iTechArt</p>
      </footer>
    );
  }
}
