import Roles from './roles';

export default {
  Main : {
    text : 'Main',
    path : '/',
    access : Roles.NEVER,
  },

  Users : {
    text : 'Users list',
    path : '/users',
    access : Roles.ADMIN,
  },

  About : {
    text : 'About company',
    path : '/about',
    access : Roles.NEVER,
  },

  AboutUs : {
    text : 'About us',
    path : '/about/about-us',
    access : Roles.NEVER,
  },

  Training : {
    text : 'Training',
    path : '/about/training',
    access : Roles.NEVER,
  },

  Benefits : {
    text : 'Benefist',
    path : '/about/benefits',
    access : Roles.NEVER,
  },

  ForStudents : {
    text : 'For students',
    path : '/about/for-students',
    access : Roles.NEVER,
  },

  OurAdvantages : {
    text : 'Our advantages',
    path : '/about/our-advantages',
    access : Roles.NEVER,
  },

  Careers : {
    text : 'Careers',
    path : '/about/careers',
    access : Roles.NEVER,
  },

  Contacts : {
    text : 'Contacts',
    path : '/about/contacts',
    access : Roles.NEVER,
  },

  SignUp : {
    text : 'SignUp',
    path : '/signup',
    access : Roles.ALL,
  },

  LogIn : {
    text : 'LogIn',
    path : '/login',
    access : Roles.ALL,
  },

  Surveys : {
    text : 'Surveys list',
    path : '/survey',
    access : Roles.USERS,
  },

  NewSurvey : {
    text : 'New survey',
    path : '/survey/new',
    access : Roles.ADMIN,
  },

  MySurveys : {
    text : 'My surveys',
    path : '/survey/my',
    access : Roles.ADMIN,
  },

  SurveyTemplates : {
    text : 'Surveys templates list',
    path : '/survey/templates',
    access : Roles.ADMIN,
  },
};
