import { createActions } from 'redux-actions';
import {
  UNAUTHORIZED,
} from 'http-status';

import {
  GET_USERS_START,
  GET_USERS_SUCCESS,
  GET_USERS_ERROR,
  GET_USERS_FILTER,
} from './actionTypes';
import { getUsers as getUsersFromServer } from './api';
import { tokenUtility } from '../utils/tokenUtility';

export const {
  getUsersStart,
  getUsersSuccess,
  getUsersError,
  getUsersFilter,
} = createActions({
  [GET_USERS_START] : () => {},

  [GET_USERS_SUCCESS] : (userList) => ({
    userList,
  }),

  [GET_USERS_ERROR] : () => {},

  [GET_USERS_FILTER] : (filterInput) => ({
    filterInput,
  }),
});

export const getUsers = () => (dispatch) => {
  dispatch(getUsersStart());
  return getUsersFromServer()
    .then((response) => {
      dispatch(getUsersSuccess(response.data));
    })
    .catch((error) => {
      dispatch(getUsersError());

      if (error.statusCode === UNAUTHORIZED) {
        tokenUtility.updateTokens();
        dispatch(getUsers());
      }
    });
};

export const setFilter = (filterInput) => getUsersFilter(filterInput);
