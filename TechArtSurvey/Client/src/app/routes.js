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
    access : Role.NEVER,
  },

  Training : {
    text : 'Training',
    path : '/about/training',
    access : Role.NEVER,
  },

  Benefits : {
    text : 'Benefist',
    path : '/about/benefits',
    access : Role.NEVER,
  },

  ForStudents : {
    text : 'For students',
    path : '/about/for-students',
    access : Role.NEVER,
  },

  OurAdvantages : {
    text : 'Our advantages',
    path : '/about/our-advantages',
    access : Role.NEVER,
  },

  Careers : {
    text : 'Careers',
    path : '/about/careers',
    access : Role.NEVER,
  },

  Contacts : {
    text : 'Contacts',
    path : '/about/contacts',
    access : Role.NEVER,
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