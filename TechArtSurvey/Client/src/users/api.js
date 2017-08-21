import urljoin from 'url-join';

import { API_URL } from '../app/config';
import { httpUtility } from '../utils/httpUtility';

export const getUsers = () => {
  return httpUtility.get(urljoin(API_URL, '/users'));
};