import { handleActions } from 'redux-actions';
import { Record } from 'immutable';

import {
  GET_SURVEY_START,
  GET_SURVEY_SUCCESS,
  GET_SURVEY_ERROR,
  SEND_RESPONSE_START,
  SEND_RESPONSE_SUCCESS,
  SEND_RESPONSE_ERROR,
} from './actionTypes';

const surveysInitialState = Record({
  isFetching : false,
  survey : {},
  error : '',
});

const initialState = new surveysInitialState();

export const passSurveyReducer = handleActions({
  [GET_SURVEY_START] : (state) =>
    state.set('isFetching', true),

  [GET_SURVEY_SUCCESS] : (state, action) =>
    state.set('isFetching', false)
      .set('survey', action.payload.survey),

  [GET_SURVEY_ERROR] : (state, action) =>
    state.set('isFetching', false)
      .set('error', action.payload.error.data),

  [SEND_RESPONSE_START] : (state) =>
    state.set('isFetching', true),

  [SEND_RESPONSE_SUCCESS] : (state) =>
    state.set('isFetching', false),

  [SEND_RESPONSE_ERROR] : (state, action) =>
    state.set('isFetching', false)
      .set('error', action.payload.error.data),

}, initialState);
