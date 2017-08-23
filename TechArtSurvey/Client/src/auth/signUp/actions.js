import { push } from 'react-router-redux';
import { createActions } from 'redux-actions';
import {
  BAD_REQUEST,
} from 'http-status';

import Routes from '../../app/routes';
import { signUp } from './api';
import {
  SIGN_UP_START,
  SIGN_UP_SUCCESS,
  SIGN_UP_FAILED,
  SIGN_UP_INVALID_DATA,
} from './actionTypes';
import { enableGreeting } from '../login/actions';

export const {
  signUpStart,
  signUpSuccess,
  signUpFailed,
  signUpInvalidData,
} = createActions({
  [SIGN_UP_START] : () => {},
  [SIGN_UP_SUCCESS] : () => {},
  [SIGN_UP_FAILED] : () => {},
  [SIGN_UP_INVALID_DATA] : (errors) => ({ errors }),
});

export const signUpRequest = (userData) => (dispatch) => {
  dispatch(signUpStart());
  return signUp(userData)
    .then(() => {
      dispatch(signUpSuccess());
      dispatch(enableGreeting('You have been signed up successfully! Now you can log in!'));
      dispatch(push(Routes.Login.path));
    })
    .catch((error) => {
      if (error.statusCode === BAD_REQUEST) {
        dispatch(signUpInvalidData(error.data));
      } else {
        dispatch(signUpFailed());
      }
    });
};
