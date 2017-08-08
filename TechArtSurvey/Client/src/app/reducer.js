import { combineReducers } from 'redux';
import { routerReducer } from 'react-router-redux';

import { usersReducer } from '../users/reducer';
import { authReducer } from '../auth/reducer';
import { signupReducer } from '../auth/signup/reducer';
import { logInReducer } from '../auth/login/reducer';

export const combinedReducer = combineReducers({
  users : usersReducer,
  routing : routerReducer,
  auth : authReducer,
  signup : signupReducer,
  login : logInReducer,
});

export default combinedReducer;
