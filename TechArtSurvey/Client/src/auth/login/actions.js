import { push } from 'react-router-redux';
import { createActions } from 'redux-actions';

import Routes from '../../app/routesConstants';
import { logIn } from './api';
import {
  USER_LOG_IN_REQUEST_START,
  USER_LOG_IN_REQUEST_SUCCESS,
  USER_LOG_IN_REQUEST_FAILED,
  USER_LOG_IN_REQUEST_INVALID_DATA,
  HTTP_STATUS_BAD_REQUEST,
} from './actionTypes';

export const {
  userLogInRequestStart,
  userLogInRequestSuccess,
  userLogInRequestFailed,
  userLogInRequestInvalidData,
} = createActions({
  [USER_LOG_IN_REQUEST_START] : () => ({
    message : 'User LogIn request START',
  }),

  [USER_LOG_IN_REQUEST_SUCCESS] : (token, refreshToken, tokenType) => ({
    token,
    refreshToken,
    tokenType,
    message : 'User LogIn request SUCCESS',
  }),

  [USER_LOG_IN_REQUEST_FAILED] : (error) => ({
    message : error,
  }),

  [USER_LOG_IN_REQUEST_INVALID_DATA] : (errors) => ({
    message : 'User LogIn request INVALID DATA',
    errors,
  }),
});

export const logInRequest = (userData) => (dispatch) => {
  dispatch(userLogInRequestStart());
  return logIn(userData)
    .then((response) => {
      if (response.status === HTTP_STATUS_BAD_REQUEST) {
        dispatch(userLogInRequestInvalidData(['Wrong email or password.']));
        return null;
      }

      return response.json();
    })
    .then((json) => {
      if (json !== null) {
        dispatch(userLogInRequestSuccess(
          json.access_token,
          json.refresh_token,
          json.token_type
        ));
        dispatch(push(Routes.Main.path));
      }
    })
    .catch((error) => {
      dispatch(userLogInRequestFailed(error));
    });
};
