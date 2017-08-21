import { combineReducers } from 'redux';

import { forgotPasswordReducer } from '../auth/forgotPassword/reducer';
import { usersReducer } from '../users/reducer';
import { authReducer } from '../auth/reducer';
import { signUpReducer } from '../auth/signUp/reducer';
import { loginReducer } from '../auth/login/reducer';
import { routerReducer } from './routerReducer';

export const combinedReducer = combineReducers({
  routing : routerReducer,
  users : usersReducer,
  auth : authReducer,
  signUp : signUpReducer,
  login : loginReducer,
  forgotPassword : forgotPasswordReducer,
});

export default combinedReducer;
