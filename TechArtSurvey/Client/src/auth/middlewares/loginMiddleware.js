// import jwt from 'jsonwebtoken';
import utf8 from 'utf8';

import { LOG_IN_SUCCESS } from '../login/actionTypes';
import { setUserToken } from '../actions';

function parseJwt (token) {
  var [ , base64Url] = token.split('.');
  var base64 = base64Url.replace('-', '+').replace('_', '/');
  return JSON.parse(window.atob(base64));
}

// console.log(jwt);

export const logInMiddleware = (store) => (next) => (action) => {
  if (action.type === LOG_IN_SUCCESS) {
    const jwt = parseJwt(action.payload.token);
    let { unique_name } = jwt;
    const { role } = jwt;
    unique_name = utf8.decode(unique_name);
    store.dispatch(setUserToken(
      action.payload.token,
      action.payload.refreshToken,
      action.payload.tokenType,
      unique_name,
      role
    ));
  }

  return next(action);
};
