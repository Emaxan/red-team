import { createActions } from 'redux-actions';
import {
  BAD_REQUEST,
} from 'http-status';

import { login } from './api';
import {
  LOGIN_START,
  LOGIN_SUCCESS,
  LOGIN_ERROR,
  LOGOUT,
  ENABLE_GREETING,
  DISABLE_GREETING,
} from './actionTypes';

export const {
  logInStart,
  logInSuccess,
  loginError,
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

  [LOGIN_ERROR] : (errors) => ({ errors }),

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
        dispatch(loginError(['Wrong email or password.']));
      } else {
        dispatch(loginError(error.data));
      }
    });
};

export const logoutRequest = () => (dispatch) => {
  dispatch(logOut());
};
