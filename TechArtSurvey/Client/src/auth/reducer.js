import { handleActions } from 'redux-actions';
import { Record } from 'immutable';

import AuthService from './authService';
import { UserInfoRecord } from './UserInfoRecord';
import { IsEmailRegisteredRecord } from './IsEmailRegisteredRecord';
import {
  SET_USER_INFO,
  RESET_USER_INFO,
  SYNC_USER_INFO,
  CHECK_EMAIL_EXISTENCE_SUCCESS,
  CHECK_EMAIL_EXISTENCE_ERROR,
} from './actionTypes';

const authInitialState = Record({
  isAuthenticated : AuthService.isAuthenticated(),
  userInfo : new UserInfoRecord(AuthService.getUserInfo()),
  isEmailRegistered : new IsEmailRegisteredRecord({ isRegistered : false }),
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
    state.set('isEmailRegistered', new IsEmailRegisteredRecord({ isRegistered : action.payload.isEmailRegistered })),

  [CHECK_EMAIL_EXISTENCE_ERROR] : (state) =>
    state.set('isEmailRegistered', new IsEmailRegisteredRecord({ isRegistered : null })),
}, initialState);
