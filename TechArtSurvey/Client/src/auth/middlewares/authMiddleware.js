import { SET_USER_TOKEN, RESET_USER_TOKEN } from '../actionTypes';
import AuthService from '../authService';

export const authMiddleware = () => (next) => (action) => {
  switch (action.type) {
  case SET_USER_TOKEN:
    AuthService.setToken(action.payload.token);
    AuthService.setTokenType(action.payload.tokenType);
    AuthService.setRefreshToken(action.payload.refreshToken);
    break;

  case RESET_USER_TOKEN:
    AuthService.clearUserInfo();
    break;
  }

  return next(action);
};
