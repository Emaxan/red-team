import { LOG_IN_SUCCESS, LOG_OUT } from '../login/actionTypes';
import { setUserToken, resetUserToken } from '../actions';

export const logInMiddleware = (store) => (next) => (action) => {
  if (action.type === LOG_IN_SUCCESS) {
    store.dispatch(setUserToken(
      action.payload.token,
      action.payload.refreshToken,
      action.payload.tokenType,
    ));
  }

  if (action.type === LOG_OUT) {
    store.dispatch(resetUserToken());
  }

  return next(action);
};
