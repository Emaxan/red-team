import { createActions } from 'redux-actions';

import AuthService from './authService';
import { checkEmailExistence } from './api';
import {
  SET_USER_INFO,
  RESET_USER_INFO,
  SYNC_USER_INFO,
  CHECK_EMAIL_EXISTENCE_START,
  CHECK_EMAIL_EXISTENCE_SUCCESS,
  CHECK_EMAIL_EXISTENCE_ERROR,
} from './actionTypes';

export const {
  setUserToken,
  resetUserToken,
  syncUserToken,
  checkEmailExistenceStart,
  checkEmailExistenceSuccess,
  checkEmailExistenceError,
} = createActions({
  [SET_USER_INFO] : () => ({
    userInfo : AuthService.getUserInfo(),
  }),

  [RESET_USER_INFO] : () => {},

  [SYNC_USER_INFO] : () => ({
    userInfo : AuthService.getUserInfo(),
    isAuthenticated : AuthService.isAuthenticated(),
  }),

  [CHECK_EMAIL_EXISTENCE_START] : () => {},

  [CHECK_EMAIL_EXISTENCE_SUCCESS] : (data) => ({
    isEmailRegistered : data,
  }),

  [CHECK_EMAIL_EXISTENCE_ERROR] : () => {},
});

export const checkEmailExistenceRequest = (email) => (dispatch) => {
  dispatch(checkEmailExistenceStart());
  return checkEmailExistence(email)
    .then((response) => {
      dispatch(checkEmailExistenceSuccess(response.data));
    })
    .catch(() => {
      dispatch(checkEmailExistenceError());
    });
};
