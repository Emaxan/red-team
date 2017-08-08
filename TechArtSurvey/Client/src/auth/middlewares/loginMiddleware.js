import { USER_LOG_IN_REQUEST_SUCCESS } from '../login/actionTypes';
import { setUserToken } from '../actions';

export const logInMiddleware = (store) => (next) => (action) => {
  if (action.type === USER_LOG_IN_REQUEST_SUCCESS) {
    store.dispatch(setUserToken(
      action.payload.token,
      action.payload.refreshToken,
      action.payload.tokenType
    ));
  }

  return next(action);
};
