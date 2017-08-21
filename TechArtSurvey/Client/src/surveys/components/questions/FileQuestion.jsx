import React, { Component } from 'react';
import PropTypes from 'prop-types';

export class FileQuestion extends Component {
  handleOnTextChanged(e) {
    const text = e.target.value.trim();
    this.props.setFilter(text);
  }

  render() {
    return <input placeholder="Search" onChange={this.handleOnTextChanged.bind(this)} />;
  }
}

FileQuestion.propTypes = {
  setFilter : PropTypes.func.isRequired,
};