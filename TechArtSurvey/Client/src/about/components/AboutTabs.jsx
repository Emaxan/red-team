import React, { Component } from 'react';
import { Tabs, Tab } from 'react-bootstrap';
import PropTypes from 'prop-types';

import './AboutTabs.scss';

class AboutTabs extends Component {

  constructor(props) {
    super(props);
    this.handleSelect = this.handleSelect.bind(this);
  }

  handleSelect(key) {
    this.props.push(this.props.tabs[key].routePath);
  }

  render() {
    return (
      <Tabs id="itechartAboutTabs" className="about-tabs" onSelect={this.handleSelect} activeKey={this.props.defaultTab}>
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
  defaultTab : PropTypes.number.isRequired,
  push : PropTypes.func.isRequired,
};

export default AboutTabs;