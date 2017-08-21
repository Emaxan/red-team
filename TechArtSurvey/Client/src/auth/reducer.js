import { handleActions } from 'redux-actions';
import { Record, List } from 'immutable';

import AuthService from './authService';
import {
  SET_USER_INFO,
  RESET_USER_INFO,
  SYNC_USER_INFO,
  CHECK_EMAIL_EXISTENCE_SUCCESS,
  CHECK_EMAIL_EXISTENCE_ERROR,
} from './actionTypes';
import { UserInfoRecord } from './UserInfoRecord';

const authInitialState = Record({
  isAuthenticated : AuthService.isAuthenticated(),
  userInfo : new UserInfoRecord(AuthService.getUserInfo()),
  isEmailRegistered : false,
  errors : List(),
});

const initialState = new authInitialState();

export const authReducer = handleActions({
  [SET_USER_INFO] : (state, action) =>
    state.set('userInfo', new UserInfoRecord(action.payload.userInfo))
      .set('isAuthenticated', true),

  [RESET_USER_INFO] : (state) =>
    state.set('userInfo', new UserInfoRecord())
      .set('isAuthenticated', false),

  [SYNC_USER_INFO] : (state, action) =>
    state.set('userInfo', new UserInfoRecord(action.payload.userInfo))
      .set('isAuthenticated', action.payload.isAuthenticated),

  [CHECK_EMAIL_EXISTENCE_SUCCESS] : (state, action) =>
    state.set('isEmailRegistered', action.payload.isEmailRegistered),

  [CHECK_EMAIL_EXISTENCE_ERROR] : (state) =>
    state.set('isEmailRegistered', false),
}, initialState);