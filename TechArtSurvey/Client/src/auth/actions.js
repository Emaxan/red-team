import { createActions } from 'redux-actions';

import { SET_USER_TOKEN } from './actionTypes';

export const {
  setUserToken,
} = createActions({
  [SET_USER_TOKEN] : (token, refreshToken, tokenType) => ({
    token,
    refreshToken,
    tokenType,
  }),
});
