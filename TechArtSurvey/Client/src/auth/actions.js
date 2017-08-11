import { createActions } from 'redux-actions';

import {
  SET_USER_TOKEN,
  RESET_USER_TOKEN,
} from './actionTypes';

export const {
  setUserToken,
  resetUserToken,
} = createActions({
  [SET_USER_TOKEN] : (token, refreshToken, tokenType, userName, userRole) => ({
    token,
    refreshToken,
    tokenType,
    userName,
    userRole,
  }),

  [RESET_USER_TOKEN] : () => ({

  }),
});
