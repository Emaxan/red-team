import { handleActions } from 'redux-actions';
import { Record, List } from 'immutable';

import {
  CREATE_SURVEY_INVALID_DATA,
} from './actionTypes';

const createSurveyInitialState = Record({
  errors : List(),
});

const initialState = createSurveyInitialState();

export const createSurveyReducer = handleActions({
  [CREATE_SURVEY_INVALID_DATA] : (state, action) =>
    state.set('errors', state.get('errors')
      .merge(List(action.payload.errors))),
}, initialState);
