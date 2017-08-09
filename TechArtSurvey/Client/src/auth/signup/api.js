import { API_URL } from '../../app/config';
import { httpUtility } from '../../utils/httpUtility';

export const signup = (signupData) => httpUtility.post(
  `${API_URL}/account/signup`,
  {
    'Content-type' : 'application/json',
  },
  {
    username : signupData.name,
    email : signupData.email,
    password : signupData.password,
  }
);

export const checkEmailExistence = (email) => httpUtility.get(
  `${API_URL}/users/?email=${email}`
);