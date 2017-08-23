import AuthService from '../auth/authService';
import { updateTokens } from '../auth/api';

export const tokenUtility = {
  updateTokens : () => {
    const refreshToken = AuthService.getRefreshToken();
    updateTokens(refreshToken).then((response) => {
      AuthService.setToken(response.data.access_token);
      AuthService.setRefreshToken(response.data.refresh_token);
    });
  },
};
