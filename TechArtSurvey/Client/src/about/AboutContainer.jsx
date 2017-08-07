import React, { Component } from 'react';

import { BasicInfo } from './components/BasicInfo';
import { AboutTabs } from './components/AboutTabs';
import { tabItems } from './tabItems';

export class AboutContainer extends Component {
  render() {
    return (
      <div className="about-content">
        <BasicInfo className="about-header" />
        <AboutTabs className="about-tabs" tabs={tabItems} />
      </div>
    );
  }
}
