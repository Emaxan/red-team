import React, { Component } from 'react';
import { Tabs, Tab } from 'react-bootstrap';
import PropTypes from 'prop-types';

import './AboutTabs.scss';

const ABOUT_TABS_DEFAULT_ACTIVE_TAB = 0;

export class AboutTabs extends Component {
  render() {
    return (
      <Tabs id="itechartAboutTabs" className="about-tabs" defaultActiveKey={ABOUT_TABS_DEFAULT_ACTIVE_TAB}>
        {
          this.props.tabs.map((item, i) => (
            <Tab eventKey={i} key={i} title={item.text} mountOnEnter unmountOnExit className="about-tabs__item clearfix">{item.content}</Tab>
          ))
        }
      </Tabs>
    );
  }
}

AboutTabs.propTypes = {
  tabs : PropTypes.array.isRequired,
};
