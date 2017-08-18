import React, { Component } from 'react';

export class InvalidTokenMessage extends Component {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <div>
        <h1>Invalid token</h1>
      </div>
    );
  }
}