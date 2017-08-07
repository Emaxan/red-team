import React, { Component } from 'react';

import { BasicInfo } from './components/BasicInfo';
import { AboutTabs } from './components/AboutTabs';
import { tabItems } from './tabItems';

export class AboutContainer extends Component {
  render() {
    return (
      <div className="about-content">
        <BasicInfo />
        <AboutTabs tabs={tabItems} />
      </div>
    );
  }
}
