import React from 'react';
import { Route, Switch, Redirect } from 'react-router-dom';
import { Nav, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';

import BasicInfo from './components/BasicInfo';
import Routes from '../app/routesConstants';
import {
  AboutUs,
  Training,
  Benefits,
  ForStudents,
  OurAdvantages,
  Careers,
  Contacts,
} from './components';

export const AboutContainer = () => (
  <div className="about-content">
    <BasicInfo />
    <Nav bsStyle="tabs" justified>
      <LinkContainer to={Routes.AboutUs.path}>
        <NavItem eventKey={Routes.AboutUs.id}>{Routes.AboutUs.text}</NavItem>
      </LinkContainer>
      <LinkContainer to={Routes.Training.path}>
        <NavItem eventKey={Routes.Training.id}>{Routes.Training.text}</NavItem>
      </LinkContainer>
      <LinkContainer to={Routes.Benefits.path}>
        <NavItem eventKey={Routes.Benefits.id}>{Routes.Benefits.text}</NavItem>
      </LinkContainer>
      <LinkContainer to={Routes.ForStudents.path}>
        <NavItem eventKey={Routes.ForStudents.id}>{Routes.ForStudents.text}</NavItem>
      </LinkContainer>
      <LinkContainer to={Routes.OurAdvantages.path}>
        <NavItem eventKey={Routes.OurAdvantages.id}>{Routes.OurAdvantages.text}</NavItem>
      </LinkContainer>
      <LinkContainer to={Routes.Careers.path}>
        <NavItem eventKey={Routes.Careers.id}>{Routes.Careers.text}</NavItem>
      </LinkContainer>
      <LinkContainer to={Routes.Contacts.path}>
        <NavItem eventKey={Routes.Contacts.id}>{Routes.Contacts.text}</NavItem>
      </LinkContainer>
    </Nav>

    <Switch>
      <Route exact path={Routes.About.path} render={() => <Redirect to={Routes.AboutUs.path} />} />
      <Route path={Routes.AboutUs.path} component={AboutUs} />
      <Route path={Routes.Training.path} component={Training} />
      <Route path={Routes.Benefits.path} component={Benefits} />
      <Route path={Routes.ForStudents.path} component={ForStudents} />
      <Route path={Routes.OurAdvantages.path} component={OurAdvantages} />
      <Route path={Routes.Careers.path} component={Careers} />
      <Route path={Routes.Contacts.path} component={Contacts} />
    </Switch>
  </div>
);
