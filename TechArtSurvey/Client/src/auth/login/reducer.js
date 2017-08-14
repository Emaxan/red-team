import { handleActions } from 'redux-actions';
import { Record, List } from 'immutable';

import {
  LOGIN_START,
  LOGIN_INVALID_DATA,
} from './actionTypes';

const loginInitialState = Record({
  message : '',
  errors : List(),
});

const initialState = loginInitialState();

export const loginReducer = handleActions({
  [LOGIN_START] : (state) =>
    state.set('errors', List()),

  [LOGIN_INVALID_DATA] : (state, action) =>
    state.set('errors', state.get('errors')
      .merge(List(action.payload.errors))),
}, initialState);
