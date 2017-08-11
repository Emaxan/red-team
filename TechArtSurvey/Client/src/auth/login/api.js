import urljoin from 'url-join';

import { AUTH_URL } from '../../app/config';
import { httpUtility } from '../../utils/httpUtility';

export const logIn = (logInData) => {
  const headers = {
    'Content-type' : 'application/x-www-form-urlencoded',
    Accept : 'application/x-www-form-urlencoded',
  };
  const body = `grant_type=password&username=${logInData.email}&password=${logInData.password}`;

  return httpUtility.post(urljoin(AUTH_URL, '/token'), headers, body);
};
