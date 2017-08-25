import { API_URL } from '../../app/config';
import { httpUtility } from '../../utils/httpUtility';

export const resetPassword = (userId, token, newPassword) => {
  const headers = {
    'Content-type' : 'application/json',
  };

  const body = {
    UserId : userId,
    ResetPasswordToken : token,
    NewPassword : newPassword,
  };

  return httpUtility.post(`${API_URL}/account/reset_password/`, headers, body);
};

export const checkPasswordResetToken = (userId, token) => {
  const headers = {
    'Content-type' : 'application/json',
  };

  const body = {
    UserId : userId,
    ResetPasswordToken : token,
  };

  return httpUtility.post(`${API_URL}/account/check_token/`, headers, body);
};
