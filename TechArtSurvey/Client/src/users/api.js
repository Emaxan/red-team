import urljoin from 'url-join';

import { API_URL } from '../app/config';
import { httpUtility } from '../utils/httpUtility';

export const getUsers = (token_type, access_token) => {
  const headers = {
    'Accept' : 'application/json',
    'Authorization' : `${token_type} ${access_token}`,
  };

  return httpUtility.get(urljoin(API_URL, '/users'), headers);
};