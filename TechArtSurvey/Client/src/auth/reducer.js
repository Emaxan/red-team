import { handleActions } from 'redux-actions';
import { Record } from 'immutable';

import AuthService from './authService';
import { SET_USER_TOKEN } from './actionTypes';

const authReducerInitialState = Record({
  token : AuthService.getToken(),
  isAuthenticated : AuthService.isAuthenticated(),
});

const initialState = new authReducerInitialState();

export const authReducer = handleActions({
  [SET_USER_TOKEN] : (state, action) =>
    state.set('token', action.payload.token).set('isAuthenticated', true),
}, initialState);
