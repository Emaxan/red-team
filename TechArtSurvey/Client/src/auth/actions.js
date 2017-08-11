import { createActions } from 'redux-actions';

import {
  SET_USER_TOKEN,
  RESET_USER_TOKEN,
} from './actionTypes';

export const {
  setUserToken,
  resetUserToken,
} = createActions({
  [SET_USER_TOKEN] : (userName, userRole, token, refreshToken, tokenType) => ({
    userName,
    userRole,
    token,
    refreshToken,
    tokenType,
  }),

  [RESET_USER_TOKEN] : () => {},
});
