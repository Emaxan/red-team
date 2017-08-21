import { createActions } from 'redux-actions';

import { forgotPassword } from './api';
import {
  FORGOT_PASSWORD_REQUEST_START,
  FORGOT_PASSWORD_REQUEST_SUCCESS,
  FORGOT_PASSWORD_REQUEST_ERROR,
} from './actionTypes';

export const {
  forgotPasswordRequestStart,
  forgotPasswordRequestSuccess,
  forgotPasswordRequestError,
} = createActions({
  [FORGOT_PASSWORD_REQUEST_START] : () => {},
  [FORGOT_PASSWORD_REQUEST_SUCCESS] : () => {},
  [FORGOT_PASSWORD_REQUEST_ERROR] : () => {},
});

export const forgotPasswordRequest = (email) => (dispatch) => {
  dispatch(forgotPasswordRequestStart());
  return forgotPassword(email)
    .then(() => {
      dispatch(forgotPasswordRequestSuccess());
    })
    .catch(() => {
      dispatch(forgotPasswordRequestError());
    });
};
