import React from 'react';

import Routes from './routesConstants';
import App from './App';
import UserListContainer from '../users/UserListContainer';
import { AboutContainer } from '../about/AboutContainer';
import AboutUs from '../about/components/AboutUs';

const Training = () => <p>{Routes.Training.text}</p>;
const Benefits = () => <p>{Routes.Benefits.text}</p>;
const ForStudents = () => <p>{Routes.ForStudents.text}</p>;
const OurAdvantages = () => <p>{Routes.OurAdvantages.text}</p>;
const Careers = () => <p>{Routes.Careers.text}</p>;
const Contacts = () => <p>{Routes.Contacts.text}</p>;

const routes = [
  {
    path : Routes.Main.path,
    component : App,
    routes : [
      {
        path : Routes.Users.path,
        component : UserListContainer,
      },
      {
        path : Routes.About.path,
        component : AboutContainer,
        routes : [
          {
            redirect : true,
            from : Routes.About.path,
            to : Routes.AboutUs.path,
          },
          {
            path : Routes.AboutUs.path,
            component : AboutUs,
          },
          {
            path : Routes.Training.path,
            component : Training,
          },
          {
            path : Routes.Benefits.path,
            component : Benefits,
          },
          {
            path : Routes.ForStudents.path,
            component : ForStudents,
          },
          {
            path : Routes.OurAdvantages.path,
            component : OurAdvantages,
          },
          {
            path : Routes.Careers.path,
            component : Careers,
          },
          {
            path : Routes.Contacts.path,
            component : Contacts,
          },
        ],
      },
    ],
  },
];

export default routes;
