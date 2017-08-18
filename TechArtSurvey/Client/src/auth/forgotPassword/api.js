import { API_URL } from '../../app/config';
import { httpUtility } from '../../utils/httpUtility';

export const forgotPassword = (email) => {
  const headers = { 'Content-type' : 'application/json' };
  const body = {
    Email : email,
    CallbackUrl : 'http://localhost:3000/reset_password',
  };

  return httpUtility.post(`${API_URL}/account/forgot_password/`, headers, body);
};
