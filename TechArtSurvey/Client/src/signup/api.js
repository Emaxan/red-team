import { API_URL } from '../app/config';

export const signup = (signupData) => fetch(`${API_URL}/users`, {
  method : 'POST',
  headers : {
    'Content-type' : 'application/json',
  },
  body : JSON.stringify(signupData),
});