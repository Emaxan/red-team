import { push } from 'react-router-redux';
import { createActions } from 'redux-actions';

import Routes from '../../app/routes';
import { signUp } from './api';
import {
  SIGN_UP_START,
  SIGN_UP_SUCCESS,
  SIGN_UP_ERROR,
} from './actionTypes';
import { enableGreeting } from '../login/actions';

export const {
  signUpStart,
  signUpSuccess,
  signUpFailed,
  signUpError,
} = createActions({
  [SIGN_UP_START] : () => {},
  [SIGN_UP_SUCCESS] : () => {},
  [SIGN_UP_ERROR] : (errors) => ({ errors }),
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
      dispatch(signUpError(error.data));
    });
};
