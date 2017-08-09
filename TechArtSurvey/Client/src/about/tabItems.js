import React from 'react';

import AboutUs from './components/AboutUs';
import Routes from '../app/routesConstants';

export const tabItems = [
  {
    text : 'About us',
    content : <AboutUs />,
    routePath : Routes.AboutUs.path,
  },
  {
    text : 'Training',
    content : 'Training',
    routePath : Routes.Training.path,
  },
  {
    text : 'Benefits',
    content : 'Benefits',
    routePath : Routes.Benefist.path,
  },
  {
    text : 'For students',
    content : 'For students',
    routePath : Routes.ForStudents.path,
  },
  {
    text : 'Our advantages',
    content : 'Our advantages',
    routePath : Routes.OurAdvantages.path,
  },
  {
    text : 'Careers',
    content : 'Careers',
    routePath : Routes.Careers.path,
  },
  {
    text : 'Contacts',
    content : 'Contacts',
    routePath : Routes.Contacts.path,
  },
];
