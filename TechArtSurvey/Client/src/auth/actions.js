import { createActions } from 'redux-actions';

import { SET_USER_TOKEN } from './actionTypes';

export const {
  setUserToken,
} = createActions({
  [SET_USER_TOKEN] : (token) => ({
    type : [SET_USER_TOKEN],
    token,
  }),
});
