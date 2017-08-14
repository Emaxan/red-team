import { RESET_USER_INFO } from '../actionTypes';
import AuthService from '../authService';

export const authMiddleware = () => (next) => (action) => {
  switch (action.type) {
  case RESET_USER_INFO:
    AuthService.clearUserInfo();
    break;
  }

  return next(action);
};
