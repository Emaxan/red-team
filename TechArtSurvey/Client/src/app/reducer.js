import { combineReducers } from 'redux';

import { routerReducer } from './routerReducer';
import { usersReducer } from '../users/reducer';
import { authReducer } from '../auth/reducer';
import { signUpReducer } from '../auth/signUp/reducer';
import { loginReducer } from '../auth/login/reducer';
import { forgotPasswordReducer } from '../auth/forgotPassword/reducer';
import { resetPasswordReducer } from '../auth/resetPassword/reducer';
import { surveyReducer } from '../reactSurvey/reducer';

export const combinedReducer = combineReducers({
  routing : routerReducer,
  users : usersReducer,
  auth : authReducer,
  signUp : signUpReducer,
  login : loginReducer,
  forgotPassword : forgotPasswordReducer,
  resetPassword : resetPasswordReducer,
  surveys: surveyReducer,
});

export default combinedReducer;
