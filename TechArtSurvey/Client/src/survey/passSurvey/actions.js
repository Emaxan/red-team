import { createActions } from 'redux-actions';
import {
  UNAUTHORIZED,
} from 'http-status';

import {
  GET_SURVEY_START,
  GET_SURVEY_SUCCESS,
  GET_SURVEY_ERROR,
} from './actionTypes';
import { getSurvey as getSurveyFromServer } from './api';
import { tokenUtility } from '../../utils/tokenUtility';

export const {
  getSurveyStart,
  getSurveySuccess,
  getSurveyError,
} = createActions({
  [GET_SURVEY_START] : () => {},
  [GET_SURVEY_SUCCESS] : (survey) => ({ survey }),
  [GET_SURVEY_ERROR] : (error) => ({ error }),
});

export const getSurvey = (id, version) => (dispatch) => {
  dispatch(getSurveyStart());
  return getSurveyFromServer(id, version)
    .then((response) => {
      dispatch(getSurveySuccess(response.data));
    })
    .catch((error) => {
      dispatch(getSurveyError(error.data));

      if (error.statusCode === UNAUTHORIZED) {
        tokenUtility.updateTokens();
        dispatch(getSurvey(id, version));
      }
    });
};
