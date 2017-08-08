import { handleActions } from 'redux-actions';
import { Record, List } from 'immutable';

import {
  USER_LOG_IN_REQUEST_START,
  USER_LOG_IN_REQUEST_SUCCESS,
  USER_LOG_IN_REQUEST_FAILED,
  USER_LOG_IN_REQUEST_INVALID_DATA,
} from './actionTypes';

const logInInitialState = Record({
  message : '',
  errors : List(),
});

const initialState = logInInitialState();

export const logInReducer = handleActions({
  [USER_LOG_IN_REQUEST_START] : (state, action) => {
    const newState = state.set('message', action.payload.message)
      .set('errors', List());
    return newState;
  },

  [USER_LOG_IN_REQUEST_SUCCESS] : (state, action) => {
    const newState = state.set('message', action.payload.message);
    return newState;
  },

  [USER_LOG_IN_REQUEST_FAILED] : (state, action) => {
    const newState = state.set('message', action.payload.er);
    return newState;
  },

  [USER_LOG_IN_REQUEST_INVALID_DATA] : (state, action) => {
    let newState = state.set('errors', state.get('errors')
      .merge(List(action.payload.errors)));
    newState = newState.set('message', action.payload.message);
    return newState;
  },
}, initialState);
