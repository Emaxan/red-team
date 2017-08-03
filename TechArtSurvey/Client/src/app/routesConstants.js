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
