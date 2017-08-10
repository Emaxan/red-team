import { handleActions } from 'redux-actions';
import { Record } from 'immutable';

import AuthService from './authService';
import { SET_USER_TOKEN, RESET_USER_TOKEN } from './actionTypes';

const authInitialState = Record({
  token : AuthService.getToken(),
  refreshToken : AuthService.getRefreshToken(),
  tokenType : AuthService.getTokenType(),
  isAuthenticated : AuthService.isAuthenticated(),
  userName : AuthService.getUserName(),
  role : AuthService.getUserRole(),
});

const initialState = new authInitialState();

export const authReducer = handleActions({
  [SET_USER_TOKEN] : (state, action) =>
    state.set('token', action.payload.token)
      .set('refreshToken', action.payload.refreshToken)
      .set('tokenType', action.payload.tokenType)
      .set('userName', action.payload.userName)
      .set('role', action.payload.userRole)
      .set('isAuthenticated', true),

  [RESET_USER_TOKEN] : () =>
    initialState,
}, initialState);
