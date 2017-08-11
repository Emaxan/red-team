import Role from './role';

export default {
  Main : {
    text : 'Main',
    path : '/',
    access : Role.NOBODY,
  },

  Users : {
    text : 'Users list',
    path : '/users',
    access : Role.ADMIN,
  },

  About : {
    text : 'About company',
    path : '/about',
    access : Role.NOBODY,
  },

  SignUp : {
    text : 'SignUp',
    path : '/signup',
    access : Role.NOBODY,
  },

  LogIn : {
    text : 'LogIn',
    path : '/login',
    access : Role.NOBODY,
  },

  Surveys : {
    text : 'Surveys list',
    path : '/survey',
    access : Role.ANY,
  },

  NewSurvey : {
    text : 'New survey',
    path : '/survey/new',
    access : Role.ADMIN,
  },

  MySurveys : {
    text : 'My surveys',
    path : '/survey/my',
    access : Role.ADMIN,
  },

  SurveyTemplates : {
    text : 'Surveys templates list',
    path : '/survey/templates',
    access : Role.ADMIN,
  },

  ForgotPassword : {
    text : 'Forgot password?',
    path : '/forgotPassword',
    access : Role.NOBODY,
  },
};
