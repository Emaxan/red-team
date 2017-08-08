import { SET_USER_TOKEN } from '../actionTypes';
import AuthService from '../authService';

export const authMiddleware = () => (next) => (action) => {
  if (action.type === SET_USER_TOKEN) {
    AuthService.setToken(action.payload.token);
    AuthService.setTokenType(action.payload.tokenType);
    AuthService.setRefreshToken(action.payload.refreshToken);
  }

  return next(action);
};
