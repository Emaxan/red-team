import { handleActions } from 'redux-actions';
import { Record, List } from 'immutable';

import {
  FORGOT_PASSWORD_REQUEST_START,
  FORGOT_PASSWORD_REQUEST_SUCCESS,
  FORGOT_PASSWORD_REQUEST_ERROR,
} from './actionTypes';

const forgotPasswordInitialState = Record({
  isFetching : false,
  resetPasswordInstructionsWereSent : false,
  email : '',
  errors : List(),
});

const initialState = forgotPasswordInitialState();

export const forgotPasswordReducer = handleActions({
  [FORGOT_PASSWORD_REQUEST_START] : (state) =>
    state.set('isFetching', true)
      .set('errors', List()),

  [FORGOT_PASSWORD_REQUEST_SUCCESS] : (state, action) =>
    state.set('isFetching', false)
      .set('resetPasswordInstructionsWereSent', true)
      .set('email', action.payload.email),

  [FORGOT_PASSWORD_REQUEST_ERROR] : (state, action) =>
    state.set('isFetching', false)
      .set('resetPasswordInstructionsWereSent', false)
      .set('errors', state.get('errors')
        .merge(List(action.payload.errors))),
}, initialState);
