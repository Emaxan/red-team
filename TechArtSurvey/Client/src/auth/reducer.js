import { handleActions } from 'redux-actions';
import { Record } from 'immutable';

import AuthService from './authService';
import { SET_USER_TOKEN, RESET_USER_TOKEN, SYNC_USER_TOKEN } from './actionTypes';

const authInitialState = Record({
  isAuthenticated : AuthService.isAuthenticated(),
  userInfo : AuthService.getUserInfo(),
});

const initialState = new authInitialState();

export const authReducer = handleActions({
  [SET_USER_TOKEN] : (state) =>
    state.set('userInfo', AuthService.getUserInfo())
      .set('isAuthenticated', AuthService.isAuthenticated()),

  [RESET_USER_TOKEN] : (state) =>
    state.set('userInfo', {})
      .set('isAuthenticated', false),

  [SYNC_USER_TOKEN] : (state) =>
    state.set('userInfo', AuthService.getUserInfo())
      .set('isAuthenticated', AuthService.isAuthenticated()),
}, initialState);