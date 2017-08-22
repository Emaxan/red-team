import { handleActions } from 'redux-actions';
import { Record, List } from 'immutable';

import {
  GET_USERS_START,
  GET_USERS_SUCCESS,
  GET_USERS_ERROR,
  GET_USERS_FILTER,
} from './actionTypes';

const usersInitialState = Record({
  fetching : false,
  userList : List(),
  filterInput : '',
});

const initialState = new usersInitialState();

export const usersReducer = handleActions({
  [GET_USERS_START] : (state) =>
    state.set('fetching', true),

  [GET_USERS_SUCCESS] : (state, action) =>
    state.set('fetching', false)
      .set('userList', state.get('userList')
        .merge(List(action.payload.userList))),

  [GET_USERS_ERROR] : (state) =>
    state.set('fetching', false),

  [GET_USERS_FILTER] : (state, action) =>
    state.set('filterInput', action.payload.filterInput),
}, initialState);
