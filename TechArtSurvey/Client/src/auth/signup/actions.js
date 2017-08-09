import { push } from 'react-router-redux';
import { createActions } from 'redux-actions';

import Routes from '../../app/routesConstants';
import { signup, checkEmailExistence } from './api';
import {
  SIGN_UP_START,
  SIGN_UP_SUCCESS,
  SIGN_UP_FAILED,
  SIGN_UP_INVALID_DATA,
  CHECK_EMAIL_EXISTENCE_START,
  CHECK_EMAIL_EXISTENCE_SUCCESS,
  CHECK_EMAIL_EXISTENCE_ERROR,
} from './actionTypes';
import {
  OK,
  BAD_REQUEST,
} from 'http-status';

export const {
  signUpStart,
  signUpSuccess,
  signUpFailed,
  signUpInvalidData,
  checkEmailExistenceStart,
  checkEmailExistenceSuccess,
  checkEmailExistenceFailed,
  checkEmailExistenceError,
} = createActions({
  [SIGN_UP_START] : () => ({
    type : [SIGN_UP_START],
    message : 'User signUp request START',
  }),

  [SIGN_UP_SUCCESS] : () => ({
    type : [SIGN_UP_SUCCESS],
    message : 'User signUp request SUCCESS',
  }),

  [SIGN_UP_FAILED] : (error) => ({
    type : [SIGN_UP_FAILED],
    message : error,
  }),

  [SIGN_UP_INVALID_DATA] : (errors) => ({
    type : [SIGN_UP_INVALID_DATA],
    message : 'User signUp request INVALID DATA',
    errors,
  }),

  [CHECK_EMAIL_EXISTENCE_START] : () => ({
    message : 'Check email existence START',
  }),

  [CHECK_EMAIL_EXISTENCE_SUCCESS] : (errors) => ({
    message : 'Check email existence SUCCESS',
    errors,
  }),

  [CHECK_EMAIL_EXISTENCE_ERROR] : (error) => ({
    message : error,
  }),
});

export const signupRequest = (userData) => (dispatch) => {
  dispatch(signUpStart());
  return signup(userData)
    .then((response) => {
      if (response.statusCode === OK) {
        dispatch(signUpSuccess());
        dispatch(push(Routes.Main.path));
      } else if (response.statusCode === BAD_REQUEST && response.data !== null) {
        dispatch(signUpInvalidData(JSON.parse(response.data)));
      }

      // Различать 500-е и 400-е ерроры
    })
    .catch((error) => {
      dispatch(signUpFailed(error));
    });
};

export const checkEmailExistenceRequest = (email) => (dispatch) => {
  dispatch(checkEmailExistenceStart());
  return checkEmailExistence(email)
    .then((response) => {
      dispatch(checkEmailExistenceSuccess(JSON.parse(response.data)));
    })
    .catch((error) => {
      dispatch(checkEmailExistenceError(error));
    });
};
