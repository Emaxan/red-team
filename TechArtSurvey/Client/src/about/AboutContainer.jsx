import React from 'react';
import { Nav, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import PropTypes from 'prop-types';

import BasicInfo from './components/BasicInfo';
import RouteWithSubRoutes from '../components/RouteWithSubRoutes';
import Routes from '../app/routesConstants';

export const AboutContainer = ({ routes }) => (
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
    {
      routes.map((route, i) => (
        <RouteWithSubRoutes key={i} {...route}/>
      ))
    }
  </div>
);

AboutContainer.propTypes = {
  routes: PropTypes.array.isRequired,
};
