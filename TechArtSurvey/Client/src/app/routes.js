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
    access : Role.NOBODY,
  },

  Login : {
    text : 'Login',
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
