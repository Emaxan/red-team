import { AUTH_API_URL } from '../../app/config';
import { httpUtility } from '../../utils/httpUtility';

export const logIn = (logInData) => {
  const headers = {
    'Content-type' : 'application/x-www-form-urlencoded',
    Accept : 'application/x-www-form-urlencoded',
  };
  const body = `grant_type=password&username=${logInData.email}&password=${logInData.password}`;

  return httpUtility.post(`${AUTH_API_URL}/token`, headers, body);
};
