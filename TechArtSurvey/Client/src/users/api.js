import { API_URL } from '../app/config';

export const getUsers = (token_type, access_token) => fetch(
  `${API_URL}/users`,
  {
    method : 'GET',
    headers : {
      'Accept' : 'application/json',
      'Authorization' : `${token_type} ${access_token}`,
    },
  }
);
