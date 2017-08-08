import { push } from 'react-router-redux';
import { createActions } from 'redux-actions';

import Routes from '../../app/routesConstants';
import { signup } from './api';
import {
  SIGN_UP_START,
  SIGN_UP_SUCCESS,
  SIGN_UP_FAILED,
  SIGN_UP_INVALID_DATA,
} from './actionTypes';
import {
  OK,
} from 'http-status';

export const {
  signUpStart,
  signUpSuccess,
  signUpFailed,
  signUpInvalidData,
} = createActions({
  [SIGN_UP_START] : () => ({
    type : [SIGN_UP_START],
    message : 'User signup request START',
  }),

  [SIGN_UP_SUCCESS] : () => ({
    type : [SIGN_UP_SUCCESS],
    message : 'User signup request SUCCESS',
  }),

  [SIGN_UP_FAILED] : (error) => ({
    type : [SIGN_UP_FAILED],
    message : error,
  }),

  [SIGN_UP_INVALID_DATA] : (errors) => ({
    type : [SIGN_UP_INVALID_DATA],
    message : 'User signup request INVALID DATA',
    errors,
  }),
});

export const signupRequest = (userData) => (dispatch) => {
  dispatch(signUpStart());
  return signup(userData)
    .then((response) => {
      if (response.status === OK) {
        dispatch(signUpSuccess());
        dispatch(push(Routes.Main.path));
      }

      // Различать 500-е и 400-е ерроры

      return response.json();
    })
    .then((json) => {
      if (json !== null) {
        dispatch(signUpInvalidData(json));
      }
    })
    .catch((error) => {
      dispatch(signUpFailed(error));
    });
};
