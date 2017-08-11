import { createActions } from 'redux-actions';
import {
  BAD_REQUEST,
} from 'http-status';

import { login } from './api';
import {
  LOGIN_START,
  LOGIN_SUCCESS,
  LOGIN_FAILED,
  LOGIN_INVALID_DATA,
  LOGOUT,
} from './actionTypes';

export const {
  logInStart,
  logInSuccess,
  logInFailed,
  logInInvalidData,
  logOut,
} = createActions({
  [LOGIN_START] : () => ({
    message : 'User Login request START',
  }),

  [LOGIN_SUCCESS] : (token, refreshToken, tokenType) => ({
    token,
    refreshToken,
    tokenType,
    message : 'User Login request SUCCESS',
  }),

  [LOGIN_FAILED] : (error) => ({
    message : error,
  }),

  [LOGIN_INVALID_DATA] : (errors) => ({
    message : 'User Login request INVALID DATA',
    errors,
  }),

  [LOGOUT] : () => ({
    message : 'User Logout request',
  }),
});

export const loginRequest = (userData) => (dispatch) => {
  dispatch(logInStart());
  return login(userData)
    .then((response) => {
      dispatch(logInSuccess(
        response.data.access_token,
        response.data.refresh_token,
        response.data.token_type,
      ));
    })
    .catch((error) => {
      if (error.statusCode === BAD_REQUEST) {
        dispatch(logInInvalidData(['Wrong email or password.']));
      } else {
        dispatch(logInFailed(error));
      }
    });
};

export const logoutRequest = () => (dispatch) => {
  dispatch(logOut());
};
