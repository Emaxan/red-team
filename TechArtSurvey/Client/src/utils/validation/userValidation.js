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
    errors.push(validationErrors.UserNameRequired);
  }

  if (name.length < USER_NAME_MIN_LENGTH) {
    errors.push(validationErrors.UserNameMinLength);
  }

  return new ValidationResult(errors.length === 0, errors);
};

export const validateEmail = (email) => {
  const errors = [];

  if (validator.isEmpty(email)) {
    errors.push(validationErrors.UserEmailRequired);
  }

  if (validator.isEmail(email) === false) {
    errors.push(validationErrors.UserEmailIncorrect);
  }

  return new ValidationResult(errors.length === 0, errors);
};

export const validatePassword = (password) => {
  const errors = [];

  if (validator.isEmpty(password)) {
    errors.push(validationErrors.UserPasswordRequired);
  }

  if (password.length < USER_PASSWORD_MIN_LENGTH) {
    errors.push(validationErrors.UserPasswordMinLength);
  }

  return new ValidationResult(errors.length === 0, errors);
};

export const validateConfirmationPassword = (password, confirmationPassword) => {
  const errors = [];

  if (validator.equals(password, confirmationPassword) === false) {
    errors.push(validationErrors.UserConfirmationPasswordMustMatch);
  }

  return new ValidationResult(errors.length === 0, errors);
};
