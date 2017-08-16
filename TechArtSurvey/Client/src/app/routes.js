import sidebarDisplay from './sidebarDisplay';

export default {
  Main : {
    text : 'Main',
    path : '/',
    display : sidebarDisplay.NOBODY,
  },

  About : {
    text : 'About company',
    path : '/about',
    display : sidebarDisplay.NOBODY,
  },

  AboutUs : {
    text : 'About us',
    path : '/about/about-us',
    display : sidebarDisplay.NOBODY,
  },

  Training : {
    text : 'Training',
    path : '/about/training',
    display : sidebarDisplay.NOBODY,
  },

  Benefits : {
    text : 'Benefist',
    path : '/about/benefits',
    display : sidebarDisplay.NOBODY,
  },

  ForStudents : {
    text : 'For students',
    path : '/about/for-students',
    display : sidebarDisplay.NOBODY,
  },

  OurAdvantages : {
    text : 'Our advantages',
    path : '/about/our-advantages',
    display : sidebarDisplay.NOBODY,
  },

  Careers : {
    text : 'Careers',
    path : '/about/careers',
    display : sidebarDisplay.NOBODY,
  },

  Contacts : {
    text : 'Contacts',
    path : '/about/contacts',
    display : sidebarDisplay.NOBODY,
  },

  SignUp : {
    text : 'SignUp',
    path : '/signup',
    display : sidebarDisplay.NOBODY,
  },

  Login : {
    text : 'Login',
    path : '/login',
    display : sidebarDisplay.NOBODY,
  },

  ForgotPassword : {
    text : 'Forgot password?',
    path : '/forgotPassword',
    display : sidebarDisplay.NOBODY,
  },

  Forbidden : {
    text : 'HTTP Forbidden (403)',
    path : '/forbidden',
    display : sidebarDisplay.NOBODY,
  },

  Surveys : {
    text : 'Surveys list',
    path : '/survey',
    display : sidebarDisplay.ANY,
    icon : 'glyphicon glyphicon-th-list',
  },

  NewSurvey : {
    text : 'New survey',
    path : '/survey/new',
    display : sidebarDisplay.ADMIN,
    icon : 'glyphicon glyphicon-plus',
  },

  MySurveys : {
    text : 'My surveys',
    path : '/survey/my',
    display : sidebarDisplay.ADMIN,
    icon : 'glyphicon glyphicon-tasks',
  },

  SurveyTemplates : {
    text : 'Surveys templates list',
    path : '/survey/templates',
    display : sidebarDisplay.ADMIN,
    icon : 'glyphicon glyphicon-book',
  },

  Users : {
    text : 'Users list',
    path : '/users',
    display : sidebarDisplay.ADMIN,
    icon : 'glyphicon glyphicon-user',
  },
};
