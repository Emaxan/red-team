import { createActions } from 'redux-actions';
import { tokenUtility } from '../utils/tokenUtility';
import { UNAUTHORIZED } from 'http-status';

import { pushSurvey, getSurvey } from './api';
import {
  SEND_SURVEY_START,
  SEND_SURVEY_ERROR,
  SEND_SURVEY_SUCCESS,
  GET_SURVEY_START,
  GET_SURVEY_ERROR,
  GET_SURVEY_SUCCESS,
} from './actionTypes';

export const {
  sendSurveyStart,
  sendSurveySuccess,
  sendSurveyError,
  getSurveyStart,
  getSurveySuccess,
  getSurveyError,
} = createActions({
  [SEND_SURVEY_START] : () => ({}),

  [SEND_SURVEY_SUCCESS] : (message) => ({ message }),

  [SEND_SURVEY_ERROR] : (errors) => ({ errors }),

  [GET_SURVEY_START] : () => ({}),

  [GET_SURVEY_SUCCESS] : (survey) => ({ survey }),

  [GET_SURVEY_ERROR] : (errors) => ({ errors }),
});

export const pushSurveyRequest = (survey) => (dispatch) => {
  dispatch(sendSurveyStart());
  return pushSurvey(survey)
    .then((response) => {
      dispatch(sendSurveySuccess(`Successfully add survey with title "${response.data.versions[0].title.default}"`));
    })
    .catch((error) => {
      if (error.statusCode === UNAUTHORIZED) {
        tokenUtility.updateTokens()
          .then(() => dispatch(pushSurveyRequest(survey)))
          .catch((e) => dispatch(sendSurveyError(e.message)));
      } else {
        dispatch(sendSurveyError(error.data));
      }
    });
};

export const getSurveyRequest = (id, version) => (dispatch) => {
  dispatch(getSurveyStart());
  return getSurvey(id, version)
    .then((response) => {
      dispatch(getSurveySuccess(response.data));
    })
    .catch((error) => {
      if (error.statusCode === UNAUTHORIZED) {
        tokenUtility.updateTokens()
          .then(() => dispatch(getSurveyRequest(id, version)))
          .catch((e) => dispatch(getSurveyError(e.message)));
      } else {
        dispatch(getSurveyError(error.data));
      }
    });
};
