import { push } from 'react-router-redux';
import { createActions } from 'redux-actions';
import {
  BAD_REQUEST,
} from 'http-status';

import { createSurvey } from './api';
import {
  CREATE_SURVEY_START,
  CREATE_SURVEY_SUCCESS,
  CREATE_SURVEY_FAILED,
  CREATE_SURVEY_INVALID_DATA,
} from './actionTypes';

export const {
  createSurveyStart,
  createSurveySuccess,
  createSurveyFailed,
  createSurveyInvalidData,
} = createActions({
  [CREATE_SURVEY_START] : () => {},
  [CREATE_SURVEY_SUCCESS] : () => {},
  [CREATE_SURVEY_FAILED] : () => {},
  [CREATE_SURVEY_INVALID_DATA] : (errors) => ({ errors }),
});

export const createSurveyRequest = (survey) => (dispatch) => {
  dispatch(createSurveyStart());
  return createSurvey(survey)
    .then(() => {
      dispatch(createSurveySuccess());
      dispatch(push('/'));
    })
    .catch((error) => {
      if (error.statusCode === BAD_REQUEST) {
        dispatch(createSurveyInvalidData(error.data));
      } else {
        dispatch(createSurveyFailed());
      }
    });
};
