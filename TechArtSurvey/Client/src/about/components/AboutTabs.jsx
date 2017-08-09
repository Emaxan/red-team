import React from 'react';
import { Tabs, Tab } from 'react-bootstrap';
import PropTypes from 'prop-types';

import './AboutTabs.scss';

const ABOUT_TABS_DEFAULT_ACTIVE_TAB = 0;

const AboutTabs = ({ tabs }) => (
  <Tabs id="itechartAboutTabs" className="about-tabs" defaultActiveKey={ABOUT_TABS_DEFAULT_ACTIVE_TAB}>
    {
      tabs.map((item, i) => (
        <Tab eventKey={i} key={i} title={item.text} mountOnEnter unmountOnExit className="about-tabs__item clearfix">{item.content}</Tab>
      ))
    }
  </Tabs>
);

AboutTabs.propTypes = {
  tabs : PropTypes.array.isRequired,
};

export default AboutTabs;