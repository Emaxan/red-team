import { combineReducers } from 'redux';
import { routerReducer } from 'react-router-redux';

import { usersReducer } from '../users/reducer';
import { authReducer } from '../auth/reducer';

export const combinedReducer = combineReducers({
  users : usersReducer,
  routing : routerReducer,
  auth : authReducer,
});

export default combinedReducer;
