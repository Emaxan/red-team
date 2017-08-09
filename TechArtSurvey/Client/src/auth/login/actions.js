import { push } from 'react-router-redux';
import { createActions } from 'redux-actions';

import Routes from '../../app/routesConstants';
import { logIn } from './api';
import {
  LOG_IN_START,
  LOG_IN_SUCCESS,
  LOG_IN_FAILED,
  LOG_IN_INVALID_DATA,
} from './actionTypes';
import {
  BAD_REQUEST,
} from 'http-status';

export const {
  logInStart,
  logInSuccess,
  logInFailed,
  logInInvalidData,
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
});

export const logInRequest = (userData) => (dispatch) => {
  dispatch(logInStart());
  return logIn(userData)
    .then((response) => {
      if (response.statusCode === BAD_REQUEST) {
        dispatch(logInInvalidData(['Wrong email or password.']));
        return null;
      }

      dispatch(logInSuccess(
        response.data.access_token,
        response.data.refresh_token,
        response.data.token_type
      ));
      dispatch(push(Routes.Main.path)); //If we dispatch it when we want redirect to another page it failed
    })
    .catch((error) => {
      dispatch(logInFailed(error));
    });
};
