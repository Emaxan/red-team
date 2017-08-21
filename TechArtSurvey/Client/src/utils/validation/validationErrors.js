import * as constants from './constants';

export const validationErrors = {
  userNameRequired : {
    id : constants.USER_NAME_REQUIRED_ERROR_ID,
    message : 'Name is required',
  },

  userNameMinLength : {
    id : constants.USER_NAME_MIN_LENGTH_ERROR_ID,
    message : `Name should have at least ${constants.USER_NAME_MIN_LENGTH} symbols`,
  },

  userEmailRequired : {
    id : constants.USER_EMAIL_REQUIRED_ERROR_ID,
    message : 'Email is required',
  },

  userEmailIncorrect : {
    id : constants.USER_EMAIL_INCORRECT_ERROR_ID,
    message : 'Email is incorrect',
  },

  userPasswordRequired : {
    id : constants.USER_PASSWORD_REQUIRED_ERROR_ID,
    message : 'Password is required',
  },

  userPasswordMinLength : {
    id : constants.USER_PASSWORD_MIN_LENGTH,
    message : `Password should have at least ${constants.USER_PASSWORD_MIN_LENGTH} symbols`,
  },

  userConfirmationPasswordMustMatch : {
    id : constants.USER_CONFIRMATION_PASSWORD_MUST_MATCH_ERROR_ID,
    message : 'Passwords must match',
  },
};