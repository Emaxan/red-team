import urljoin from 'url-join';
import { httpUtility, buildQueryStringByObject } from '../utils/httpUtility';
import { FORM_URL_ENCODED_DATA } from '../utils/MimeType';

import { AUTH_URL, API_URL } from '../app/config';

export const updateTokens = (refreshToken) => {
  const headers = {
    'Content-Type' : FORM_URL_ENCODED_DATA,
    'Accept' : FORM_URL_ENCODED_DATA,
  };

  const body = {
    'grant_type' : 'refresh_token',
    'refresh_token' : refreshToken,
  };

  return httpUtility.post(`${AUTH_URL}/token`, headers, buildQueryStringByObject(body));
};

export const checkEmailExistence = (email) => {
  return httpUtility.get(urljoin(API_URL, `/users/?email=${email}`));
};
