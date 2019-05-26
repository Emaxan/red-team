import { handleActions } from 'redux-actions';
import { Record, List } from 'immutable';

import {
  GET_SURVEYS_START,
  GET_SURVEYS_SUCCESS,
  GET_SURVEYS_ERROR,
  GET_SURVEYS_FILTER,
  SURVEYS_CLEAN,
} from './actionTypes';

const surveysInitialState = Record({
  isFetching : false,
  surveyList : List(),
  error : '',
  filterInput : '',
});

const initialState = new surveysInitialState();

export const surveyListReducer = handleActions({
  [GET_SURVEYS_START] : (state) =>
    state.set('isFetching', true),

  [GET_SURVEYS_SUCCESS] : (state, action) =>
    state.set('isFetching', false)
      .set('surveyList', state.get('surveyList')
        .merge(List(action.payload.surveyList))),

  [GET_SURVEYS_ERROR] : (state, action) =>
    state.set('isFetching', false)
      .set('error', action.payload.error.data),

  [GET_SURVEYS_FILTER] : (state, action) =>
    state.set('filterInput', action.payload.filterInput),

  [SURVEYS_CLEAN] : (state) =>
    state.set('surveyList', List()),
}, initialState);
