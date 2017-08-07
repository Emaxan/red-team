import { API_URL } from '../../app/config';

export const signup = (signupData) => fetch(`${API_URL}/account/signup`, {
  method : 'POST',
  headers : {
    'Content-type' : 'application/json',
  },
  body : JSON.stringify({
    username : signupData.name,
    email : signupData.email,
    password : signupData.password,
  }),
});