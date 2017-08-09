import { API_URL } from '../app/config';
import { httpUtility } from '../utils/httpUtility';

export const getUsers = (token_type, access_token) => httpUtility.get(
  `${API_URL}/users`,
  {
    'Accept' : 'application/json',
    'Authorization' : `${token_type} ${access_token}`,
  }
);
