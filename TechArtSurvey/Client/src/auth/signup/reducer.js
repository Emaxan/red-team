import { handleActions } from 'redux-actions';
import { Record, List } from 'immutable';

import {
  SIGN_UP_START,
  SIGN_UP_SUCCESS,
  SIGN_UP_FAILED,
  SIGN_UP_INVALID_DATA,
} from './actionTypes';

const signUpInitialState = Record({
  message : '',
  errors : List(),
});

const initialState = signUpInitialState();

export const signupReducer = handleActions({
  [SIGN_UP_START] : (state, action) => {
    const newState = state.set('message', action.payload.message);
    return newState;
  },

  [SIGN_UP_SUCCESS] : (state, action) => {
    const newState = state.set('message', action.payload.message);
    return newState;
  },

  [SIGN_UP_FAILED] : (state, action) => {
    const newState = state.set('message', action.payload.er);
    return newState;
  },

  [SIGN_UP_INVALID_DATA] : (state, action) => {
    let newState = state.set('errors', state.get('errors')
      .merge(List(action.payload.errors)));
    newState = newState.set('message', action.payload.message);
    return newState;
  },
}, initialState);
