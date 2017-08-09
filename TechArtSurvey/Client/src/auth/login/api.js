import { AUTH_API_URL } from '../../app/config';
import { httpUtility } from '../../utils/httpUtility';

export const logIn = (logInData) => httpUtility.post(
  `${AUTH_API_URL}/token`,
  {
    'Content-type' : 'application/x-www-form-urlencoded',
    Accept : 'application/x-www-form-urlencoded',
  },
  `grant_type=password&username=${logInData.email}&password=${logInData.password}`,
);
