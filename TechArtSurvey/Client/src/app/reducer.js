import { combineReducers } from 'redux';

import { usersReducer } from '../users/reducer';
import { authReducer } from '../auth/reducer';
import { signUpReducer } from '../auth/signUp/reducer';
import { loginReducer } from '../auth/login/reducer';
import { routerReducer } from './routerReducer';

export const combinedReducer = combineReducers({
  users : usersReducer,
  routing : routerReducer,
  auth : authReducer,
  signUp : signUpReducer,
  login : loginReducer,
});

export default combinedReducer;
