import { createActions } from 'redux-actions';

import { logIn } from './api';
import {
  LOG_IN_START,
  LOG_IN_SUCCESS,
  LOG_IN_FAILED,
  LOG_IN_INVALID_DATA,
  LOG_OUT,
} from './actionTypes';
import {
  BAD_REQUEST,
} from 'http-status';

export const {
  logInStart,
  logInSuccess,
  logInFailed,
  logInInvalidData,
  logOut,
} = createActions({
  [LOG_IN_START] : () => ({
    message : 'User LogIn request START',
  }),

  [LOG_IN_SUCCESS] : (token, refreshToken, tokenType) => ({
    token,
    refreshToken,
    tokenType,
    message : 'User LogIn request SUCCESS',
  }),

  [LOG_IN_FAILED] : (error) => ({
    message : error,
  }),

  [LOG_IN_INVALID_DATA] : (errors) => ({
    message : 'User LogIn request INVALID DATA',
    errors,
  }),

  [LOG_OUT] : () => ({
    message : 'User LogOut request',
  }),
});

export const logInRequest = (userData) => (dispatch) => {
  dispatch(logInStart());
  return logIn(userData)
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

export const logOutRequest = () => (dispatch) => {
  dispatch(logOut());
};
