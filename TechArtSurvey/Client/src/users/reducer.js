import { handleActions } from 'redux-actions';
import { Record, List } from 'immutable';

import {
  GET_USERS_START,
  GET_USERS_SUCCESS,
  GET_USERS_ERROR,
  GET_USERS_FILTER,
} from './actionTypes';

const rec = Record({
  message : '',
  fetching : false,
  userList : List(),
  filterInput : '',
});

const initialState = new rec();

export const usersReducer = handleActions({
  [GET_USERS_START] : (state, action) => {
    let newState = state.set('message', action.payload.message);
    newState = newState.set('fetching', true);
    return newState;
  },

  [GET_USERS_SUCCESS] : (state, action) => {
    let newState = state.set('message', action.payload.message);
    newState = newState.set('fetching', false);
    newState = newState.set('userList', state.get('userList')
      .merge(List(action.payload.userList)));
    return newState;
  },

  [GET_USERS_ERROR] : (state, action) => {
    let newState = state.set('message', action.payload.message);
    newState = newState.set('fetching', false);
    return newState;
  },

  [GET_USERS_FILTER] : (state, action) => {
    const newState = state.set('filterInput', action.payload.filterInput);
    return newState;
  },
}, initialState);
