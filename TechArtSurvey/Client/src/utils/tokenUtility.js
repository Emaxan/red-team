import AuthService from '../auth/authService';
import { updateTokens } from '../auth/api';

export const tokenUtility = {
  updateTokens : async () => {
    const refreshToken = AuthService.getRefreshToken();
    await updateTokens(refreshToken).then((response) => {
      AuthService.setToken(response.data.access_token);
      AuthService.setRefreshToken(response.data.refresh_token);
    });
  },
};
