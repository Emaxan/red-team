import urljoin from 'url-join';

import { API_URL } from '../app/config';
import { httpUtility } from '../utils/httpUtility';
import AuthService from '../auth/authService';

export const getUsers = () => {
  const tokenType = AuthService.getTokenType();
  const accessToken = AuthService.getToken();

  const headers = {
    'Accept' : 'application/json',
    'Authorization' : `${tokenType} ${accessToken}`,
  };

  return httpUtility.get(urljoin(API_URL, '/users'), headers);
};