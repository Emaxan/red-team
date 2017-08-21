import { AUTH_URL } from '../app/config';
import { httpUtility } from '../utils/httpUtility';
import { FORM_URL_ENCODED_DATA } from '../utils/MimeType';

export const updateTokens = (refreshToken) => {
  const headers = {
    'Content-Type' : FORM_URL_ENCODED_DATA,
    'Accept' : FORM_URL_ENCODED_DATA,
  };

  const body = `grant_type=refresh_token&refresh_token=${refreshToken}`;

  return httpUtility.post(`${AUTH_URL}/token`, headers, body);
};