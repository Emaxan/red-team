import { SET_USER_TOKEN } from '../actionTypes';
import AuthService from '../authService';

export const authMiddleware = () => (next) => (action) => {
  if (action.type === SET_USER_TOKEN) {
    AuthService.setToken(action.payload.token);
    AuthService.setTokenType(action.payload.tokenType);
    AuthService.setRefreshToken(action.payload.refreshToken);
    AuthService.setUserName(action.payload.userName);
    AuthService.setUserRole(action.payload.userRole);
  }

  return next(action);
};
