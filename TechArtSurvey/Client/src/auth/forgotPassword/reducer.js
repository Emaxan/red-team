import { handleActions } from 'redux-actions';
import { Record } from 'immutable';

import {
  FORGOT_PASSWORD_REQUEST_SUCCESS,
  FORGOT_PASSWORD_REQUEST_ERROR,
} from './actionTypes';

const forgotPasswordInitialState = Record({
  messageWasSent : false,
});

const initialState = forgotPasswordInitialState();

export const forgotPasswordReducer = handleActions({
  [FORGOT_PASSWORD_REQUEST_SUCCESS] : (state) =>
    state.set('messageWasSent', true),

  [FORGOT_PASSWORD_REQUEST_ERROR] : (state) =>
    state.set('messageWasSent', false),
}, initialState);
