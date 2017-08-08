import { LOG_IN_SUCCESS } from '../login/actionTypes';
import { setUserToken } from '../actions';

export const logInMiddleware = (store) => (next) => (action) => {
  if (action.type === LOG_IN_SUCCESS) {
    store.dispatch(setUserToken(
      action.payload.token,
      action.payload.refreshToken,
      action.payload.tokenType
    ));
  }

  return next(action);
};
