import urljoin from 'url-join';

import { API_URL } from '../app/config';
import { httpUtility } from '../utils/httpUtility';

export const getUsers = () => {
  const headers = {
    'Accept' : 'application/json',
  };

  return httpUtility.get(urljoin(API_URL, '/users'), headers);
};