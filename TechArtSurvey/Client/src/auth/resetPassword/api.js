import { API_URL } from '../../app/config';
import { httpUtility } from '../../utils/httpUtility';

export const resetPassword = (id, code, newPassword) => {
  const headers = { 'Content-type' : 'application/json' };
  const body = {
    UserId : id,
    ResetPasswordToken : code,
    NewPassword : newPassword,
  };

  return httpUtility.post(`${API_URL}/account/reset_password/`, headers, body);
};

export const checkCode = (id, code) => {
  const headers = { 'Content-type' : 'application/json' };
  const body = {
    UserId : id,
    Token : code,
  };

  return httpUtility.post(`${API_URL}/account/check_code/`, headers, body);
};
