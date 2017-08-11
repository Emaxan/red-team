import { AUTH_URL } from '../app/config';
import { httpUtility } from '../utils/httpUtility';

export const updateTokens = (refreshToken) => {
  const headers = {
    'Content-Type' : 'application/x-www-form-urlencoded',
    'Accept' : 'application/x-www-form-urlencoded',
  };

  const body = `grant_type=refresh_token&refresh_token=${refreshToken}`;

  return httpUtility.post(`${AUTH_URL}/token`, headers, body);
};