import { handleActions } from 'redux-actions';
import { Record } from 'immutable';

import {
  CHECK_PASSWORD_RESET_TOKEN_SUCCESS,
  CHECK_PASSWORD_RESET_TOKEN_ERROR,
} from './actionTypes';

const resetPasswordInitialState = Record({
  tokenValid : false,
});

const initialState = resetPasswordInitialState();

export const resetPasswordReducer = handleActions({
  [CHECK_PASSWORD_RESET_TOKEN_SUCCESS] : (state) =>
    state.set('tokenValid', true),

  [CHECK_PASSWORD_RESET_TOKEN_ERROR] : (state) =>
    state.set('tokenValid', false),
}, initialState);
