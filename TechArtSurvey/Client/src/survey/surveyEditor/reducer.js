import { handleActions } from 'redux-actions';
import { Record } from 'immutable';

import {
  SEND_SURVEY_ERROR,
  SEND_SURVEY_START,
  SEND_SURVEY_SUCCESS,
  GET_SURVEY_START,
  GET_SURVEY_ERROR,
  GET_SURVEY_SUCCESS,
} from './actionTypes';

const surveyInitialState = Record({
  message : '',
  survey : {
    'pages' : [
      {
        'name' : 'page1',
      },
    ],
  },
  error : '',
  fetch : false,
});

const initialState = new surveyInitialState();

export const surveyReducer = handleActions({
  [SEND_SURVEY_START] : (state) =>
    state.set('fetch', true),

  [SEND_SURVEY_SUCCESS] : (state, action) =>
    state.set('fetch', false)
      .set('message', action.payload.message),

  [SEND_SURVEY_ERROR] : (state, action) =>
    state.set('fetch', false)
      .set('error', action.payload.errors),

  [GET_SURVEY_START] : (state) =>
    state.set('fetch', true),

  [GET_SURVEY_ERROR] : (state, action) =>
    state.set('fetch', false)
      .set('error', action.payload.errors),

  [GET_SURVEY_SUCCESS] : (state, action) =>
    state.set('fetch', false)
      .set('survey', action.payload.survey),
}, initialState);
