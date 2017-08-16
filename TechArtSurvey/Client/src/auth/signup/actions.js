import { push } from 'react-router-redux';
import { createActions } from 'redux-actions';
import {
  BAD_REQUEST,
} from 'http-status';

import Routes from '../../app/routes';
import { signUp, checkEmailExistence } from './api';
import {
  SIGN_UP_START,
  SIGN_UP_SUCCESS,
  SIGN_UP_FAILED,
  SIGN_UP_INVALID_DATA,
  CHECK_EMAIL_EXISTENCE_START,
  CHECK_EMAIL_EXISTENCE_SUCCESS,
  CHECK_EMAIL_EXISTENCE_ERROR,
  CHECK_EMAIL_EXISTENCE_INVALID,
} from './actionTypes';

export const {
  signUpStart,
  signUpSuccess,
  signUpFailed,
  signUpInvalidData,
  checkEmailExistenceStart,
  checkEmailExistenceSuccess,
  checkEmailExistenceFailed,
  checkEmailExistenceError,
  checkEmailExistenceInvalid,
} = createActions({
  [SIGN_UP_START] : () => {},

  [SIGN_UP_SUCCESS] : () => {},

  [SIGN_UP_FAILED] : () => {},

  [SIGN_UP_INVALID_DATA] : (errors) => ({
    errors,
  }),

  [CHECK_EMAIL_EXISTENCE_START] : () => {},

  [CHECK_EMAIL_EXISTENCE_SUCCESS] : () => {},

  [CHECK_EMAIL_EXISTENCE_ERROR] : () => {},

  [CHECK_EMAIL_EXISTENCE_INVALID] : (errors) => ({
    errors,
  }),
});

export const signUpRequest = (userData) => (dispatch) => {
  dispatch(signUpStart());
  return signUp(userData)
    .then(() => {
      dispatch(signUpSuccess());
      dispatch(push(Routes.Main.path));
    })
    .catch((error) => {
      if (error.statusCode === BAD_REQUEST) {
        dispatch(signUpInvalidData(error.data));
      } else {
        dispatch(signUpFailed());
      }
    });
};

export const checkEmailExistenceRequest = (email) => (dispatch) => {
  dispatch(checkEmailExistenceStart());
  return checkEmailExistence(email)
    .then(() => {
      dispatch(checkEmailExistenceSuccess());
    })
    .catch((error) => {
      if (error.statusCode === BAD_REQUEST) {
        dispatch(checkEmailExistenceInvalid(error.data));
      } else {
        dispatch(checkEmailExistenceError());
      }
    });
};
