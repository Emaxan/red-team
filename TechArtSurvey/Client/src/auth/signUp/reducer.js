import { handleActions } from 'redux-actions';
import { Record, List } from 'immutable';

import {
  SIGN_UP_START,
  SIGN_UP_ERROR,
} from './actionTypes';

const signUpInitialState = Record({
  errors : List(),
});

const initialState = signUpInitialState();

export const signUpReducer = handleActions({
  [SIGN_UP_START] : (state) =>
    state.set('errors', List()),

  [SIGN_UP_ERROR] : (state, action) =>
    state.set('errors', state.get('errors')
      .merge(List(action.payload.errors))),
}, initialState);
