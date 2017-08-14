import { RESET_USER_TOKEN } from '../actionTypes';
import AuthService from '../authService';

export const authMiddleware = () => (next) => (action) => {
  switch (action.type) {
  case RESET_USER_TOKEN:
    AuthService.clearUserInfo();
    break;
  }

  return next(action);
};
