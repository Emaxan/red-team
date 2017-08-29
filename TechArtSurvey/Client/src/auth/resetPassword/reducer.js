import { handleActions } from 'redux-actions';
import { Record } from 'immutable';

import {
  CHECK_PASSWORD_RESET_TOKEN_START,
  CHECK_PASSWORD_RESET_TOKEN_SUCCESS,
  CHECK_PASSWORD_RESET_TOKEN_ERROR,
} from './actionTypes';

const resetPasswordInitialState = Record({
  isFetching : true,
  tokenValid : false,
});

const initialState = resetPasswordInitialState();

export const resetPasswordReducer = handleActions({
  [CHECK_PASSWORD_RESET_TOKEN_START] : (state) =>
    state.set('isFetching', true),

  [CHECK_PASSWORD_RESET_TOKEN_SUCCESS] : (state, action) =>
    state.set('isFetching', false).set('tokenValid', action.payload.tokenValid),

  [CHECK_PASSWORD_RESET_TOKEN_ERROR] : (state) =>
    state.set('isFetching', false).set('tokenValid', false),
}, initialState);
