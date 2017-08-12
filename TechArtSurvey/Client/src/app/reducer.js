import { combineReducers } from 'redux';

import { usersReducer } from '../users/reducer';
import { authReducer } from '../auth/reducer';
import { signupReducer } from '../auth/signup/reducer';
import { loginReducer } from '../auth/login/reducer';
import { routerReducer } from './routerReducer';

export const combinedReducer = combineReducers({
  users : usersReducer,
  routing : routerReducer,
  auth : authReducer,
  signup : signupReducer,
  login : loginReducer,
});

export default combinedReducer;
