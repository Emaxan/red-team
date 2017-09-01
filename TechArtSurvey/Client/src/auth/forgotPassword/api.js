import urljoin from 'url-join';

import { API_URL, SERVER_ROOT_URL } from '../../app/config';
import { httpUtility } from '../../utils/httpUtility';
import appRoutes from '../../app/routes';

export const forgotPassword = (email) => {
  const headers = {
    'Content-type' : 'application/json',
  };

  const body = {
    Email : email,
    CallbackUrl : urljoin(SERVER_ROOT_URL, appRoutes.ResetPassword.path),
  };

  return httpUtility.post(`${API_URL}/account/forgot_password/`, headers, body);
};
