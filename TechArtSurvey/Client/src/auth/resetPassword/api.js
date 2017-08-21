import { API_URL } from '../../app/config';
import { httpUtility } from '../../utils/httpUtility';

export const resetPassword = (id, code, newPassword) => {
  const headers = { 'Content-type' : 'application/json' };  // remove when sign up pull request will be approved
  const body = {
    UserId : id,
    ResetPasswordToken : code,
    NewPassword : newPassword,
  };

  return httpUtility.post(`${API_URL}/account/reset_password/`, headers, body);
};

export const checkPasswordResetToken = (userId, token) => {
  const headers = { 'Content-type' : 'application/json' };  // remove when sign up pull request will be approved
  const body = {
    UserId : userId,
    Token : token,
  };

  return httpUtility.post(`${API_URL}/account/check_token/`, headers, body);
};
