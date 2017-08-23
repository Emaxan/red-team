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
  ENABLE_GREETING,
  DISABLE_GREETING,
} from './actionTypes';

export const {
  logInStart,
  logInSuccess,
  logInFailed,
  logInInvalidData,
  logOut,
  enableGreeting,
  disableGreeting,
} = createActions({
  [LOGIN_START] : () => {},

  [LOGIN_SUCCESS] : (token, refreshToken, tokenType) => ({
    token,
    refreshToken,
    tokenType,
  }),

  [LOGIN_FAILED] : () => {},

  [LOGIN_INVALID_DATA] : (errors) => ({ errors }),

  [LOGOUT] : () => {},

  [ENABLE_GREETING] : (greetingMessage) => ({ greetingMessage }),

  [DISABLE_GREETING] : () => {},
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
        dispatch(logInFailed());
      }
    });
};

export const logoutRequest = () => (dispatch) => {
  dispatch(logOut());
};
