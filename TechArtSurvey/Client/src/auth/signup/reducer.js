import { handleActions } from 'redux-actions';
import { Record, List } from 'immutable';

import {
  SIGN_UP_START,
  SIGN_UP_SUCCESS,
  SIGN_UP_FAILED,
  SIGN_UP_INVALID_DATA,
  CHECK_EMAIL_EXISTENCE_START,
  CHECK_EMAIL_EXISTENCE_SUCCESS,
  CHECK_EMAIL_EXISTENCE_ERROR,
  CHECK_EMAIL_EXISTENCE_INVALID,
} from './actionTypes';

const signUpInitialState = Record({
  message : '',
  errors : List(),
});

const initialState = signUpInitialState();

export const signupReducer = handleActions({
  [SIGN_UP_START] : (state, action) =>
    state.set('message', action.payload.message),

  [SIGN_UP_SUCCESS] : (state, action) =>
    state.set('message', action.payload.message),

  [SIGN_UP_FAILED] : (state, action) =>
    state.set('message', action.payload.message),

  [SIGN_UP_INVALID_DATA] : (state, action) =>
    state.set('errors', state.get('errors')
      .merge(List(action.payload.errors)))
      .set('message', action.payload.message),

  [CHECK_EMAIL_EXISTENCE_START] : (state, action) =>
    state.set('message', action.payload.message),

  [CHECK_EMAIL_EXISTENCE_SUCCESS] : (state, action) =>
    state.set('message', action.payload.message)
      .set('errors', List()),

  [CHECK_EMAIL_EXISTENCE_ERROR] : (state, action) =>
    state.set('message', action.payload.message),

  [CHECK_EMAIL_EXISTENCE_INVALID] : (state, action) =>
    state.set('errors', List(action.payload.errors))
      .set('message', action.payload.message),
}, initialState);
