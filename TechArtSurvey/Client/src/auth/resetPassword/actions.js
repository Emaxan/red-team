import { createActions } from 'redux-actions';

import { checkPasswordResetToken } from './api';
import {
  CHECK_PASSWORD_RESET_TOKEN_START,
  CHECK_PASSWORD_RESET_TOKEN_SUCCESS,
  CHECK_PASSWORD_RESET_TOKEN_ERROR,
} from './actionTypes';

export const {
  checkPasswordResetTokenStart,
  checkPasswordResetTokenSuccess,
  checkPasswordResetTokenError,
} = createActions({
  [CHECK_PASSWORD_RESET_TOKEN_START] : () => {},
  [CHECK_PASSWORD_RESET_TOKEN_SUCCESS] : () => {},
  [CHECK_PASSWORD_RESET_TOKEN_ERROR] : () => {},
});

export const checkPasswordResetTokenRequest = (userId, token) => (dispatch) => {
  console.log('checkPasswordResetTokenRequest');
  dispatch(checkPasswordResetTokenStart());
  return checkPasswordResetToken(userId, token)
    .then(() => {
      dispatch(checkPasswordResetTokenSuccess());
    })
    .catch(() => {
      dispatch(checkPasswordResetTokenError());
    });
};
