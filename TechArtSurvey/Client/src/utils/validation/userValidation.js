import validator from 'validator';

import {
  USER_NAME_MIN_LENGTH,
  USER_PASSWORD_MIN_LENGTH,
} from './constants';
import { validationErrors } from './validationErrors';
import ValidationResult from './validationResult';

export const validateName = (name) => {
  let errors = [];

  if (validator.isEmpty(name)) {
    errors.push(validationErrors.userNameRequired);
  }

  if (name.length < USER_NAME_MIN_LENGTH) {
    errors.push(validationErrors.userNameMinLength);
  }

  return new ValidationResult(errors.length === 0, errors);
};

export const validateEmail = (email) => {
  const errors = [];

  if (validator.isEmpty(email)) {
    errors.push(validationErrors.userEmailRequired);
  }

  if (validator.isEmail(email) === false) {
    errors.push(validationErrors.userEmailIncorrect);
  }

  return new ValidationResult(errors.length === 0, errors);
};

export const validatePassword = (password) => {
  const errors = [];

  if (validator.isEmpty(password)) {
    errors.push(validationErrors.userPasswordRequired);
  }

  if (password.length < USER_PASSWORD_MIN_LENGTH) {
    errors.push(validationErrors.userPasswordMinLength);
  }

  return new ValidationResult(errors.length === 0, errors);
};

export const validateConfirmationPassword = (password, confirmationPassword) => {
  const errors = [];

  if (validator.equals(password, confirmationPassword) === false) {
    errors.push(validationErrors.userConfirmationPasswordMustMatch);
  }

  return new ValidationResult(errors.length === 0, errors);
};
