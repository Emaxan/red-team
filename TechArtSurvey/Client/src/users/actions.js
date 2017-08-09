import { createActions } from 'redux-actions';
import {
  OK,
  BAD_REQUEST,
} from 'http-status';

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

export const getUsers = (token_type, access_token) => (dispatch) => {
  dispatch(getUsersStart());
  return getUsersFromServer(token_type, access_token)
    .then((response) => {
      if (response.statusCode === OK) {
        dispatch(getUsersSuccess(response.data));
      } else if (response.statusCode === BAD_REQUEST) {
        if(response.data !== null) {
          dispatch(getUsersError(response.data));
        } else {
          dispatch(getUsersError(response.statusCode));
        }
      }
    })
    .catch((error) => dispatch(getUsersError(error)));
};

export const setFilter = (filterInput) => getUsersFilter(filterInput);
