import { createActions } from 'redux-actions';
import AuthService from './authService';

import {
  SET_USER_INFO,
  RESET_USER_INFO,
  SYNC_USER_INFO,
} from './actionTypes';

export const {
  setUserToken,
  resetUserToken,
  syncUserToken,
} = createActions({
  [SET_USER_INFO] : () => ({
    userInfo : AuthService.getUserInfo(),
  }),

  [RESET_USER_INFO] : () => {},

  [SYNC_USER_INFO] : () => ({
    userInfo : AuthService.getUserInfo(),
    isAuthenticated : AuthService.isAuthenticated(),
  }),
});
