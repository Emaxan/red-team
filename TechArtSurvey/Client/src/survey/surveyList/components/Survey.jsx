import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { Link } from 'react-router-dom';
import Routes from '../../../app/routes';

import './Survey.scss';

export class Survey extends Component {
  constructor(props) {
    super(props);
  }

  render = () => {
    return (
      <div className="survey">
        <h2><Link to={Routes.Surveys.path + '/' + this.props.id + '/' + this.props.version + '/' + this.props.locale}>{this.props.title}</Link></h2>
        <p>{this.props.author}</p>
        <p>Default locale is {this.props.locale.toUpperCase()}.</p>
        <p>
          You can pass it from <time dateTime={new Date(this.props.startDate).valueOf()}>{new Date(this.props.startDate).toLocaleDateString('en')}</time> to
          to <time dateTime={new Date(this.props.endDate).valueOf()}>{new Date(this.props.endDate).toLocaleDateString('en')}</time>.
        </p>
      </div>
    );
  }
}

Survey.propTypes = {
  title: PropTypes.string.isRequired,
  author: PropTypes.string.isRequired,
  locale: PropTypes.string.isRequired,
  id: PropTypes.number.isRequired,
  version: PropTypes.number.isRequired,
  startDate: PropTypes.string.isRequired,
  endDate: PropTypes.string.isRequired,
};
