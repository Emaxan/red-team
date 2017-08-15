import Role from './role';

export default {
  Main : {
    text : 'Main',
    path : '/',
    access : Role.NOBODY,
  },

  About : {
    text : 'About company',
    path : '/about',
    access : Role.NOBODY,
  },

  AboutUs : {
    text : 'About us',
    path : '/about/about-us',
    access : Role.NOBODY,
  },

  Training : {
    text : 'Training',
    path : '/about/training',
    access : Role.NOBODY,
  },

  Benefits : {
    text : 'Benefist',
    path : '/about/benefits',
    access : Role.NOBODY,
  },

  ForStudents : {
    text : 'For students',
    path : '/about/for-students',
    access : Role.NOBODY,
  },

  OurAdvantages : {
    text : 'Our advantages',
    path : '/about/our-advantages',
    access : Role.NOBODY,
  },

  Careers : {
    text : 'Careers',
    path : '/about/careers',
    access : Role.NOBODY,
  },

  Contacts : {
    text : 'Contacts',
    path : '/about/contacts',
    access : Role.NOBODY,
  },

  SignUp : {
    text : 'SignUp',
    path : '/signup',
    access : Role.NOBODY,
  },

  Login : {
    text : 'Login',
    path : '/login',
    access : Role.NOBODY,
  },

  ForgotPassword : {
    text : 'Forgot password?',
    path : '/forgotPassword',
    access : Role.NOBODY,
  },

  Forbidden : {
    text : 'HTTP Forbidden (403)',
    path : '/forbidden',
    access : Role.NOBODY,
  },

  Surveys : {
    text : 'Surveys list',
    path : '/survey',
    access : Role.ANY,
    icon : 'glyphicon glyphicon-th-list',
  },

  NewSurvey : {
    text : 'New survey',
    path : '/survey/new',
    access : Role.ADMIN,
    icon : 'glyphicon glyphicon-plus',
  },

  MySurveys : {
    text : 'My surveys',
    path : '/survey/my',
    access : Role.ADMIN,
    icon : 'glyphicon glyphicon-tasks',
  },

  SurveyTemplates : {
    text : 'Surveys templates list',
    path : '/survey/templates',
    access : Role.ADMIN,
    icon : 'glyphicon glyphicon-book',
  },

  Users : {
    text : 'Users list',
    path : '/users',
    access : Role.ADMIN,
    icon : 'glyphicon glyphicon-user',
  },
};
