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
  [LOG_IN_START] : (state, action) => {
    const newState = state.set('message', action.payload.message)
      .set('errors', List());
    return newState;
  },

  [LOG_IN_SUCCESS] : (state, action) => {
    const newState = state.set('message', action.payload.message);
    return newState;
  },

  [LOG_IN_FAILED] : (state, action) => {
    const newState = state.set('message', action.payload.er);
    return newState;
  },

  [LOG_IN_INVALID_DATA] : (state, action) => {
    let newState = state.set('errors', state.get('errors')
      .merge(List(action.payload.errors)));
    newState = newState.set('message', action.payload.message);
    return newState;
  },
}, initialState);
