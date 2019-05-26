import urljoin from 'url-join';

import { API_URL } from '../../app/config';
import { httpUtility } from '../../utils/httpUtility';

export const getSurveys = (userEmail) => {
  return httpUtility.get(urljoin(API_URL, '/surveys' + (userEmail.length>0 ? `?userEmail=${userEmail}` : '')));
};
