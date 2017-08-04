import validator from 'validator';
import {
  USER_NAME_MIN_LENGTH,
  USER_PASSWORD_MIN_LENGTH,
} from './constants';

export const validateName = (name) => {
  let error = null;

  if (validator.isEmpty(name)) {
    error = 'Name is required';
  } else if (name.length < USER_NAME_MIN_LENGTH) {
    error = 'Name should have at least 5 symbols';
  }

  return error;
};

export const validateEmail = (email) => {
  let error = null;

  if (validator.isEmpty(email)) {
    error = 'E-mail is required';
  } else if (validator.isEmail(email) === false) {
    error = 'Incorrect e-mail';
  }

  return error;
};

export const validatePassword = (password) => {
  let error = null;

  if (validator.isEmpty(password)) {
    error = 'Password is required';
  } else if (password.length < USER_PASSWORD_MIN_LENGTH) {
    error = 'Password should have at least 8 symbols';
  }

  return error;
};

export const validateConfirmationPassword = (password, confirmationPassword) => {
  let error = null;

  if (validator.equals(password, confirmationPassword) === false) {
    error = 'Passwords must match';
  }

  return error;
};
