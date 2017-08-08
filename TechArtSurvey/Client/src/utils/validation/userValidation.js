import validator from 'validator';
import {
  USER_NAME_MIN_LENGTH,
  USER_PASSWORD_MIN_LENGTH,
} from './constants';
import { errorsInformation } from './errorsInformation';

export const validateName = (name) => {
  let validationInfo = {
    isValid : false,
    errors : [],
  };

  if (validator.isEmpty(name)) {
    validationInfo.errors.push(errorsInformation.userNameRequired);
  }

  if (name.length < USER_NAME_MIN_LENGTH) {
    validationInfo.errors.push(errorsInformation.userNameMinLength);
  }

  return {...validationInfo, isValid : !validationInfo.errors.length };
};

export const validateEmail = (email) => {
  let validationInfo = {
    isValid : false,
    errors : [],
  };

  if (validator.isEmpty(email)) {
    validationInfo.errors.push(errorsInformation.userEmailRequired);
  }

  if (validator.isEmail(email) === false) {
    validationInfo.errors.push(errorsInformation.userEmailIncorrect);
  }

  return {...validationInfo, isValid : !validationInfo.errors.length };
};

export const validatePassword = (password) => {
  let validationInfo = {
    isValid : false,
    errors : [],
  };

  if (validator.isEmpty(password)) {
    validationInfo.errors.push(errorsInformation.userPasswordRequired);
  }

  if (password.length < USER_PASSWORD_MIN_LENGTH) {
    validationInfo.errors.push(errorsInformation.userPasswordMinLength);
  }

  return {...validationInfo, isValid : !validationInfo.errors.length };
};

export const validateConfirmationPassword = (password, confirmationPassword) => {
  let validationInfo = {
    isValid : false,
    errors : [],
  };

  if (validator.equals(password, confirmationPassword) === false) {
    validationInfo.errors.push(errorsInformation.userConfirmationPasswordMustMatch);
  }

  return {...validationInfo, isValid : !validationInfo.errors.length };
};
