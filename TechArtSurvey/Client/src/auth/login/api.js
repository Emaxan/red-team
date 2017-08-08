import { AUTH_API_URL } from '../../app/config';

export const logIn = (logInData) => fetch(`${AUTH_API_URL}/token`, {
  method : 'POST',
  headers : {
    'Content-type' : 'application/x-www-form-urlencoded',
    Accept : 'application/x-www-form-urlencoded',
  },
  body : `grant_type=password&username=${logInData.email}&password=${logInData.password}`,
});
