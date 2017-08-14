import { handleActions } from 'redux-actions';
import { Record } from 'immutable';

import AuthService from './authService';
import {
  SET_USER_TOKEN,
  RESET_USER_TOKEN,
  SYNC_USER_TOKEN,
} from './actionTypes';

const UserInfoRecord = new Record({
  userName : '',
  role : '',
});

const authInitialState = Record({
  isAuthenticated : AuthService.isAuthenticated(),
  userInfo : new UserInfoRecord(AuthService.getUserInfo()),
});

const initialState = new authInitialState();

export const authReducer = handleActions({
  [SET_USER_TOKEN] : (state, action) =>
    state.set('userInfo', new UserInfoRecord(action.payload.userInfo))
      .set('isAuthenticated', true),

  [RESET_USER_TOKEN] : (state) =>
    state.set('userInfo', new UserInfoRecord())
      .set('isAuthenticated', false),

  [SYNC_USER_TOKEN] : (state, action) =>
    state.set('userInfo', new UserInfoRecord(action.payload.userInfo))
      .set('isAuthenticated', action.payload.isAuthenticated),
}, initialState);