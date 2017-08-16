import { handleActions } from 'redux-actions';
import { Record, List } from 'immutable';

import {
  LOGIN_START,
  LOGIN_INVALID_DATA,
  ENABLE_GREETING,
  DISABLE_GREETING,
} from './actionTypes';

const loginInitialState = Record({
  isGreetingEnabled : false,
  errors : List(),
});

const initialState = loginInitialState();

export const loginReducer = handleActions({
  [LOGIN_START] : (state) =>
    state.set('errors', List()),

  [LOGIN_INVALID_DATA] : (state, action) =>
    state.set('errors', state.get('errors')
      .merge(List(action.payload.errors))),

  [ENABLE_GREETING] : (state) =>
    state.set('isGreetingEnabled', true),

  [DISABLE_GREETING] : (state) =>
    state.set('isGreetingEnabled', false),
}, initialState);
