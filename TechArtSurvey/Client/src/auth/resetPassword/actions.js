import { createActions } from 'redux-actions';
import { push } from 'react-router-redux';

import Routes from '../../app/routes';
import { checkPasswordResetToken, resetPassword } from './api';
import {
  CHECK_PASSWORD_RESET_TOKEN_START,
  CHECK_PASSWORD_RESET_TOKEN_SUCCESS,
  CHECK_PASSWORD_RESET_TOKEN_ERROR,
  RESET_PASSWORD_START,
  RESET_PASSWORD_SUCCESS,
  RESET_PASSWORD_ERROR,
} from './actionTypes';
import { enableGreeting } from '../login/actions';

export const {
  checkPasswordResetTokenStart,
  checkPasswordResetTokenSuccess,
  checkPasswordResetTokenError,
  resetPasswordStart,
  resetPasswordSuccess,
  resetPasswordError,
} = createActions({
  [CHECK_PASSWORD_RESET_TOKEN_START] : () => {},
  [CHECK_PASSWORD_RESET_TOKEN_SUCCESS] : () => {},
  [CHECK_PASSWORD_RESET_TOKEN_ERROR] : () => {},

  [RESET_PASSWORD_START] : () => {},
  [RESET_PASSWORD_SUCCESS] : () => {},
  [RESET_PASSWORD_ERROR] : () => {},
});

export const checkPasswordResetTokenRequest = (userId, token) => (dispatch) => {
  dispatch(checkPasswordResetTokenStart());
  return checkPasswordResetToken(userId, token)
    .then(() => {
      dispatch(checkPasswordResetTokenSuccess());
    })
    .catch(() => {
      dispatch(checkPasswordResetTokenError());
    });
};

export const resetPasswordRequest = (userId, token, newPassword) => (dispatch) => {
  dispatch(resetPasswordStart());
  return resetPassword(userId, token, newPassword)
    .then(() => {
      dispatch(resetPasswordSuccess());
      dispatch(enableGreeting('Your password was reset successfully! Now you can log in!'));
      dispatch(push(Routes.Login.path));
    })
    .catch(() => {
      dispatch(resetPasswordError());
    });
};
