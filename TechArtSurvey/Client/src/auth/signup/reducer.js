import { handleActions } from 'redux-actions';
import { Record, List } from 'immutable';

import {
  SIGN_UP_INVALID_DATA,
  CHECK_EMAIL_EXISTENCE_SUCCESS,
  CHECK_EMAIL_EXISTENCE_INVALID,
} from './actionTypes';

const signUpInitialState = Record({
  errors : List(),
});

const initialState = signUpInitialState();

export const signUpReducer = handleActions({
  [SIGN_UP_INVALID_DATA] : (state, action) =>
    state.set('errors', state.get('errors')
      .merge(List(action.payload.errors))),

  [CHECK_EMAIL_EXISTENCE_SUCCESS] : (state) =>
    state.set('errors', List()),

  [CHECK_EMAIL_EXISTENCE_INVALID] : (state, action) =>
    state.set('errors', List(action.payload.errors)),
}, initialState);
