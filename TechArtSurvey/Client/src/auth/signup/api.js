import urljoin from 'url-join';

import { API_URL } from '../../app/config';
import { httpUtility } from '../../utils/httpUtility';

export const signUp = (signUpData) => {
  const headers = { 'Content-type' : 'application/json' };
  const body = {
    username : signUpData.name,
    email : signUpData.email,
    password : signUpData.password,
  };

  return httpUtility.post(urljoin(API_URL, '/account/signup'), headers, body);
};
