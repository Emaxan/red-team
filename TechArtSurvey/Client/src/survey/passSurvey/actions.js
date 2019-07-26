import { createActions } from 'redux-actions';
import {
  UNAUTHORIZED,
} from 'http-status';
// import { push } from 'react-router-redux';

import {
  GET_SURVEY_START,
  GET_SURVEY_SUCCESS,
  GET_SURVEY_ERROR,
  SEND_RESPONSE_START,
  SEND_RESPONSE_SUCCESS,
  SEND_RESPONSE_ERROR,
} from './actionTypes';
import { getSurvey as getSurveyFromServer, sendResponseCall } from './api';
import { tokenUtility } from '../../utils/tokenUtility';
// import Routes from '../../app/routes';

export const {
  getSurveyStart,
  getSurveySuccess,
  getSurveyError,
  sendResponseStart,
  sendResponseSuccess,
  sendResponseError,
} = createActions({
  [GET_SURVEY_START] : () => {},
  [GET_SURVEY_SUCCESS] : (survey) => ({ survey }),
  [GET_SURVEY_ERROR] : (error) => ({ error }),
  [SEND_RESPONSE_START] : () => ({}),
  [SEND_RESPONSE_SUCCESS] : (response) => ({ response }),
  [SEND_RESPONSE_ERROR] : (error) => ({ error }),
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

export const sendResponse = (responseData) => (dispatch) => {
  dispatch(sendResponseStart());
  return sendResponseCall(responseData)
    .then((response) => {
      dispatch(sendResponseSuccess(response.data));
      // dispatch(push(Routes.Main.path));
    })
    .catch((error) => {
      dispatch(sendResponseError(error.data));

      if (error.statusCode === UNAUTHORIZED) {
        tokenUtility.updateTokens();
        dispatch(sendResponse(responseData));
      }
    });
};
