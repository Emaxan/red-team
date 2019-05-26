import urljoin from 'url-join';

import { API_URL } from '../../app/config';
import { httpUtility } from '../../utils/httpUtility';
import { JSON_DATA } from '../../utils/MimeType';

export const getSurvey = (id, version) => {
  return httpUtility.get(urljoin(API_URL, `/surveys/${id}/${version}`));
};

export const sendResponseCall = (response) => {
  const headers = {
    'Content-Type' : JSON_DATA,
    'Accept' : JSON_DATA,
  };

  return httpUtility.post(urljoin(API_URL, '/pass_survey/'), headers, response);
};
