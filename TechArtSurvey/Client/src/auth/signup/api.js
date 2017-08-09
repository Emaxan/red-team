import { API_URL } from '../../app/config';
import { httpUtility } from '../../utils/httpUtility';

export const signup = (signupData) => {
  const headers = { 'Content-type' : 'application/json' };
  const body = JSON.stringify({
    username : signupData.name,
    email : signupData.email,
    password : signupData.password,
  });

  return httpUtility.post(`${API_URL}/account/signup`, headers, body);
};

export const checkEmailExistence = (email) => {
  return httpUtility.get(`${API_URL}/users/?email=${email}`);
};