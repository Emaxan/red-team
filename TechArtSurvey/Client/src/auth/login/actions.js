import { push } from 'react-router-redux';
import { createActions } from 'redux-actions';

import Routes from '../../app/routesConstants';
import { logIn } from './api';
import {
  LOG_IN_START,
  LOG_IN_SUCCESS,
  LOG_IN_FAILED,
  LOG_IN_INVALID_DATA,
  HTTP_STATUS_BAD_REQUEST,
} from './actionTypes';

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
      if (response.status === HTTP_STATUS_BAD_REQUEST) {
        dispatch(logInInvalidData(['Wrong email or password.']));
        return null;
      }

      return response.json();
    })
    .then((json) => {
      if (json !== null) {
        dispatch(logInSuccess(
          json.access_token,
          json.refresh_token,
          json.token_type
        ));
        dispatch(push(Routes.Main.path));//If we dispath it when we want redirect to anothr page it failed
      }
    })
    .catch((error) => {
      dispatch(logInFailed(error));
    });
};
