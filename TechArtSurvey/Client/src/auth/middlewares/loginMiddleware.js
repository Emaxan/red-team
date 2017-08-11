import { LOGIN_SUCCESS, LOGOUT } from '../login/actionTypes';
import { setUserToken, resetUserToken } from '../actions';

export const loginMiddleware = (store) => (next) => (action) => {
  switch (action.type) {
  case LOGIN_SUCCESS:
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
