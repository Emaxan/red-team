import { createActions } from 'redux-actions';

import {
  GET_USERS_START,
  GET_USERS_SUCCESS,
  GET_USERS_ERROR,
  GET_USERS_FILTER,
} from './actionTypes';
import { getUsers as getUsersFromServer } from './api';

export const {
  getUsersStart,
  getUsersSuccess,
  getUsersError,
  getUsersFilter,
} = createActions({
  [GET_USERS_START] : () => ({
    message : 'request started',
  }),

  [GET_USERS_SUCCESS] : (userList) => ({
    userList,
    message : 'request succeeded',
  }),

  [GET_USERS_ERROR] : (message) => ({
    message,
  }),

  [GET_USERS_FILTER] : (filterInput) => ({
    filterInput,
  }),
});

export const getUsers = () => (dispatch) => {
  dispatch(getUsersStart());
  return getUsersFromServer()
    .then((response) => response.json())
    .then((json) => dispatch(getUsersSuccess(json)))
    .catch((error) => dispatch(getUsersError(error)));
};

export const setFilter = (filterInput) => getUsersFilter(filterInput);
