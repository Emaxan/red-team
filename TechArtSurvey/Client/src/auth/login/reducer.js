import { handleActions } from 'redux-actions';
import { Record, List } from 'immutable';

import {
  LOGIN_START,
  LOGIN_SUCCESS,
  LOGIN_FAILED,
  LOGIN_INVALID_DATA,
} from './actionTypes';

const loginInitialState = Record({
  message : '',
  errors : List(),
});

const initialState = loginInitialState();

export const loginReducer = handleActions({
  [LOGIN_START] : (state, action) =>
    state.set('message', action.payload.message)
      .set('errors', List()),

  [LOGIN_SUCCESS] : (state, action) =>
    state.set('message', action.payload.message),

  [LOGIN_FAILED] : (state, action) =>
    state.set('message', action.payload.message),

  [LOGIN_INVALID_DATA] : (state, action) =>
    state.set('errors', state.get('errors')
      .merge(List(action.payload.errors)))
      .set('message', action.payload.message),
}, initialState);
