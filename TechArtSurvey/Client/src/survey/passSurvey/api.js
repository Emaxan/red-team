import urljoin from 'url-join';

import { API_URL } from '../../app/config';
import { httpUtility } from '../../utils/httpUtility';

export const getSurvey = (id, version) => {
  return httpUtility.get(urljoin(API_URL, `/surveys/${id}/${version}`));
};
