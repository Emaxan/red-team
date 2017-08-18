import sidebarDisplay from './sidebarDisplay';

export default {
  Main : {
    text : 'Main',
    path : '/',
    access : sidebarDisplay.NOBODY,
  },

  About : {
    text : 'About company',
    path : '/about',
    access : sidebarDisplay.NOBODY,
  },

  AboutUs : {
    text : 'About us',
    path : '/about/about-us',
    access : sidebarDisplay.NOBODY,
  },

  Training : {
    text : 'Training',
    path : '/about/training',
    access : sidebarDisplay.NOBODY,
  },

  Benefits : {
    text : 'Benefist',
    path : '/about/benefits',
    access : sidebarDisplay.NOBODY,
  },

  ForStudents : {
    text : 'For students',
    path : '/about/for-students',
    access : sidebarDisplay.NOBODY,
  },

  OurAdvantages : {
    text : 'Our advantages',
    path : '/about/our-advantages',
    access : sidebarDisplay.NOBODY,
  },

  Careers : {
    text : 'Careers',
    path : '/about/careers',
    access : sidebarDisplay.NOBODY,
  },

  Contacts : {
    text : 'Contacts',
    path : '/about/contacts',
    access : sidebarDisplay.NOBODY,
  },

  SignUp : {
    text : 'SignUp',
    path : '/signup',
    access : sidebarDisplay.NOBODY,
  },

  Login : {
    text : 'Login',
    path : '/login',
    access : sidebarDisplay.NOBODY,
  },

  ForgotPassword : {
    text : 'Forgot password?',
    path : '/forgot_password',
    access : sidebarDisplay.NOBODY,
  },

  ResetPassword : {
    text : 'Reset password',
    path : '/reset_password/:id/:code+',
    access : sidebarDisplay.NOBODY,
  },

  Forbidden : {
    text : 'HTTP Forbidden (403)',
    path : '/forbidden',
    access : sidebarDisplay.NOBODY,
  },

  Surveys : {
    text : 'Surveys list',
    path : '/survey',
    access : sidebarDisplay.ANY,
    icon : 'glyphicon glyphicon-th-list',
  },

  NewSurvey : {
    text : 'New survey',
    path : '/survey/new',
    access : sidebarDisplay.ADMIN,
    icon : 'glyphicon glyphicon-plus',
  },

  MySurveys : {
    text : 'My surveys',
    path : '/survey/my',
    access : sidebarDisplay.ADMIN,
    icon : 'glyphicon glyphicon-tasks',
  },

  SurveyTemplates : {
    text : 'Surveys templates list',
    path : '/survey/templates',
    access : sidebarDisplay.ADMIN,
    icon : 'glyphicon glyphicon-book',
  },

  Users : {
    text : 'Users list',
    path : '/users',
    access : sidebarDisplay.ADMIN,
    icon : 'glyphicon glyphicon-user',
  },
};
