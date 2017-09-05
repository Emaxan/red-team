import { handleActions } from 'redux-actions';
import { Record, List } from 'immutable';

import {
  GET_USERS_START,
  GET_USERS_SUCCESS,
  GET_USERS_ERROR,
  GET_USERS_FILTER,
} from './actionTypes';

const usersInitialState = Record({
  isFetching : false,
  userList : List(),
  filterInput : '',
});

const initialState = new usersInitialState();

export const usersReducer = handleActions({
  [GET_USERS_START] : (state) =>
    state.set('isFetching', true),

  [GET_USERS_SUCCESS] : (state, action) =>
    state.set('isFetching', false)
      .set('userList', state.get('userList')
        .merge(List(action.payload.userList))),

  [GET_USERS_ERROR] : (state) =>
    state.set('isFetching', false),

  [GET_USERS_FILTER] : (state, action) =>
    state.set('filterInput', action.payload.filterInput),
}, initialState);
