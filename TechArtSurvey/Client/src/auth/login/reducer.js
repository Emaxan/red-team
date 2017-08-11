import { handleActions } from 'redux-actions';
import { Record, List } from 'immutable';

import {
  LOG_IN_START,
  LOG_IN_SUCCESS,
  LOG_IN_FAILED,
  LOG_IN_INVALID_DATA,
} from './actionTypes';

const logInInitialState = Record({
  message : '',
  errors : List(),
});

const initialState = logInInitialState();

export const logInReducer = handleActions({
  [LOG_IN_START] : (state, action) =>
    state.set('message', action.payload.message)
      .set('errors', List()),

  [LOG_IN_SUCCESS] : (state, action) =>
    state.set('message', action.payload.message),

  [LOG_IN_FAILED] : (state, action) =>
    state.set('message', action.payload.message),

  [LOG_IN_INVALID_DATA] : (state, action) =>
    state.set('errors', state.get('errors')
      .merge(List(action.payload.errors)))
      .set('message', action.payload.message),
}, initialState);
