import urljoin from 'url-join';

import { API_URL } from '../app/config';
import { httpUtility } from '../utils/httpUtility';

export const createSurvey = (survey) => {
  const headers = {
    'Content-type' : 'application/json',
  };

  return httpUtility.post(urljoin(API_URL, '/surveys/create'), headers, survey);
};
