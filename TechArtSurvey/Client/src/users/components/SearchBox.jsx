import React, { Component } from 'react';
import PropTypes from 'prop-types';

export class SearchBox extends Component {
  handleOnTextChanged = (event) => {
    const text = event.target.value.trim();
    this.props.setFilter(text);
  }

  render = () => {
    return <input
      placeholder="Search"
      onChange={this.handleOnTextChanged.bind(this)}
    />;
  }
}

SearchBox.propTypes = {
  setFilter : PropTypes.func.isRequired,
};
