import {
  USER_NAME_MIN_LENGTH,
  USER_PASSWORD_MIN_LENGTH,
} from './constants';

export const validationErrors = {
  userNameRequired : {
    id : 1,
    message : 'Name is required',
  },

  userNameMinLength : {
    id : 2,
    message : `Name should have at least ${USER_NAME_MIN_LENGTH} symbols`,
  },

  userEmailRequired : {
    id : 3,
    message : 'Email is required',
  },

  userEmailIncorrect : {
    id : 4,
    message : 'Email is incorrect',
  },

  userPasswordRequired : {
    id : 5,
    message : 'Password is required',
  },

  userPasswordMinLength : {
    id : 6,
    message : `Password should have at least ${USER_PASSWORD_MIN_LENGTH} symbols`,
  },

  userConfirmationPasswordMustMatch : {
    id : 7,
    message : 'Passwords must match',
  },
};