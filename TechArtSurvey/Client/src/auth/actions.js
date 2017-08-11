import { createActions } from 'redux-actions';

import {
  SET_USER_TOKEN,
  RESET_USER_TOKEN,
  SYNC_USER_TOKEN,
} from './actionTypes';

export const {
  setUserToken,
  resetUserToken,
  syncUserToken,
} = createActions({
  [SET_USER_TOKEN] : (token, refreshToken, tokenType) => ({
    token,
    refreshToken,
    tokenType,
  }),

  [RESET_USER_TOKEN] : () => {},

  [SYNC_USER_TOKEN] : () => {},
});
