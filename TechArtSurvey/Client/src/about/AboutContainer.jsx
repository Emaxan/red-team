import React from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import { push } from 'react-router-redux';

import BasicInfo from './components/BasicInfo';
import AboutTabs from './components/AboutTabs';
import { tabItems } from './tabItems';

function mapStateToProps() {
  return {
    tabs : tabItems,
  };
}

const mapDispatchToProps = {
  push,
};

const AboutContainer = ({ tabs, defaultTab, push }) => (
  <div className="about-content">
    <BasicInfo />
    <AboutTabs tabs={tabs} defaultTab={defaultTab} push={push}/>
  </div>
);

AboutContainer.propTypes = {
  ...AboutTabs.propTypes,
  defaultTab : PropTypes.number.isRequired,
};

export default connect(mapStateToProps, mapDispatchToProps)(AboutContainer);