import { createActions } from 'redux-actions';
import {
  UNAUTHORIZED,
} from 'http-status';

import {
  GET_SURVEYS_START,
  GET_SURVEYS_SUCCESS,
  GET_SURVEYS_ERROR,
  GET_SURVEYS_FILTER,
  SURVEYS_CLEAN,
} from './actionTypes';
import { getSurveys as getSurveysFromServer } from './api';
import { tokenUtility } from '../../utils/tokenUtility';

export const {
  getSurveysStart,
  getSurveysSuccess,
  getSurveysError,
  getSurveysFilter,
  surveysClean,
} = createActions({
  [GET_SURVEYS_START] : () => {},
  [GET_SURVEYS_SUCCESS] : (surveyList) => ({ surveyList }),
  [GET_SURVEYS_ERROR] : ( error ) => ({ error }),
  [GET_SURVEYS_FILTER] : (filterInput) => ({ filterInput }),
  [SURVEYS_CLEAN] : () => {},
});

export const getSurveys = (userEmail) => (dispatch) => {
  dispatch(getSurveysStart());
  return getSurveysFromServer(userEmail)
    .then((response) => {
      dispatch(getSurveysSuccess(response.data));
    })
    .catch((error) => {
      dispatch(getSurveysError(error.data));

      if (error.statusCode === UNAUTHORIZED) {
        tokenUtility.updateTokens();
        dispatch(getSurveys(userEmail));
      }
    });
};

export const setFilter = (filterInput) => getSurveysFilter(filterInput);

export const cleanSurveys = () => (dispatch) => dispatch(surveysClean());
