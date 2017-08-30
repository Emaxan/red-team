import { handleActions } from 'redux-actions';
import { Record, List } from 'immutable';

import {
  RESET_PASSWORD_START,
  RESET_PASSWORD_ERROR,
  CHECK_PASSWORD_RESET_TOKEN_START,
  CHECK_PASSWORD_RESET_TOKEN_SUCCESS,
  CHECK_PASSWORD_RESET_TOKEN_ERROR,
} from './actionTypes';

const resetPasswordInitialState = Record({
  isFetching : true,
  tokenValid : false,
  errors : List(),
});

const initialState = resetPasswordInitialState();

export const resetPasswordReducer = handleActions({
  [RESET_PASSWORD_START] : (state) =>
    state.set('errors', List()),

  [RESET_PASSWORD_ERROR] : (state, action) =>
    state.set('errors', state.get('errors')
      .merge(List(action.payload.errors))),

  [CHECK_PASSWORD_RESET_TOKEN_START] : (state) =>
    state.set('isFetching', true),

  [CHECK_PASSWORD_RESET_TOKEN_SUCCESS] : (state, action) =>
    state.set('isFetching', false)
      .set('tokenValid', action.payload.tokenValid),

  [CHECK_PASSWORD_RESET_TOKEN_ERROR] : (state) =>
    state.set('isFetching', false)
      .set('tokenValid', false),
}, initialState);
