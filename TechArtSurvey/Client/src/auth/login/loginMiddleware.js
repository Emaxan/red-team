import { LOGIN_SUCCESS, LOGOUT } from './actionTypes';
import { setUserToken, resetUserToken } from '../actions';
import AuthService from '../authService';

export const loginMiddleware = (store) => (next) => (action) => {
  switch (action.type) {
  case LOGIN_SUCCESS:
    AuthService.setToken(action.payload.token);
    AuthService.setTokenType(action.payload.tokenType);
    AuthService.setRefreshToken(action.payload.refreshToken);

    store.dispatch(setUserToken(
      action.payload.token,
      action.payload.refreshToken,
      action.payload.tokenType,
    ));
    break;

  case LOGOUT:
    store.dispatch(resetUserToken());
    break;
  }

  return next(action);
};
