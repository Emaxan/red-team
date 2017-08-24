import { API_URL } from '../../app/config';
import { httpUtility } from '../../utils/httpUtility';
import { RESET_PASSWORD_CALLBACK_URL } from '../../app/config';

export const forgotPassword = (email) => {
  const headers = {
    'Content-type' : 'application/json',
  };

  const body = {
    Email : email,
    CallbackUrl : RESET_PASSWORD_CALLBACK_URL,
  };

  return httpUtility.post(`${API_URL}/account/forgot_password/`, headers, body);
};
