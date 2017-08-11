import { LOG_IN_SUCCESS, LOG_OUT } from '../login/actionTypes';
import { setUserToken, resetUserToken } from '../actions';

export const logInMiddleware = (store) => (next) => (action) => {
  switch (action.type) {
  case LOG_IN_SUCCESS:
    store.dispatch(setUserToken(
      action.payload.token,
      action.payload.refreshToken,
      action.payload.tokenType,
    ));
    break;

  case LOG_OUT:
    store.dispatch(resetUserToken());
    break;
  }

  return next(action);
};
