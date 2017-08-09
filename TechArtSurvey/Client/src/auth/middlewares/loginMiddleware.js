import jwt_decode from 'jwt-decode';

import { LOG_IN_SUCCESS, LOG_OUT } from '../login/actionTypes';
import { setUserToken, resetUserToken } from '../actions';

export const logInMiddleware = (store) => (next) => (action) => {
  if (action.type === LOG_IN_SUCCESS) {
    const jwt = jwt_decode(action.payload.token);
    let { unique_name } = jwt;
    const { role } = jwt;
    store.dispatch(setUserToken(
      action.payload.token,
      action.payload.refreshToken,
      action.payload.tokenType,
      unique_name,
      role
    ));
  }

  if (action.type === LOG_OUT) {
    store.dispatch(resetUserToken());
  }

  return next(action);
};
