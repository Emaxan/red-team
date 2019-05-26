import { httpUtility } from '../../utils/httpUtility';
import { JSON_DATA } from '../../utils/MimeType';

import { API_URL } from '../../app/config';

export const pushSurvey = (survey) => {
  const headers = {
    'Content-Type' : JSON_DATA,
    'Accept' : JSON_DATA,
  };

  return httpUtility.post(`${API_URL}/surveys`, headers, survey);
};

export const getSurvey = (id, version) => {
  const headers = {
    'Content-Type' : JSON_DATA,
    'Accept' : JSON_DATA,
  };

  return httpUtility.get(`${API_URL}/surveys/${id}/${version}`, headers);
};
