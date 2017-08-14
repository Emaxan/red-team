import { createActions } from 'redux-actions';
import AuthService from './authService';

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
  [SET_USER_TOKEN] : () => ({
    userInfo : AuthService.getUserInfo(),
  }),

  [RESET_USER_TOKEN] : () => {},

  [SYNC_USER_TOKEN] : () => ({
    userInfo : AuthService.getUserInfo(),
    isAuthenticated : AuthService.isAuthenticated(),
  }),
});
