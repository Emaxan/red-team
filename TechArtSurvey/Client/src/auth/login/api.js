import urljoin from 'url-join';

import { AUTH_URL } from '../../app/config';
import { httpUtility, buildQueryStringByObject } from '../../utils/httpUtility';
import { FORM_URL_ENCODED_DATA } from '../../utils/MimeType';

export const login = (loginData) => {
  const headers = {
    'Content-type' : FORM_URL_ENCODED_DATA,
    'Accept' : FORM_URL_ENCODED_DATA,
  };

  const body = {
    'grant_type' : 'password',
    'username' : loginData.email,
    'password' : loginData.password,
  };

  return httpUtility.post(urljoin(AUTH_URL, '/token'), headers, buildQueryStringByObject(body));
};
