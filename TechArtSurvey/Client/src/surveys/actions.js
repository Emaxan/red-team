import { push } from 'react-router-redux';
import { createActions } from 'redux-actions';

import { createSurvey } from './api';
import {
  CREATE_SURVEY_START,
  CREATE_SURVEY_SUCCESS,
  CREATE_SURVEY_ERROR,
} from './actionTypes';

export const {
  createSurveyStart,
  createSurveySuccess,
  createSurveyError,
} = createActions({
  [CREATE_SURVEY_START] : () => {},
  [CREATE_SURVEY_SUCCESS] : () => {},
  [CREATE_SURVEY_ERROR] : (error) => ({ error }),
});

export const createSurveyRequest = (survey) => (dispatch) => {
  dispatch(createSurveyStart());
  return createSurvey(survey)
    .then(() => {
      dispatch(createSurveySuccess());
      dispatch(push('/'));
    })
    .catch((error) => {
      dispatch(createSurveyError(error));
    });
};

export const cancelSurveyCreationRequest = () => (dispatch) => dispatch(push('/'));
