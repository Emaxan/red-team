const token = 'auth.token';
const refreshToken = 'auth.refreshToken';
const tokenType = 'auth.tokenType';

export default class AuthService {
  static setToken(accessToken) {
    window.localStorage.setItem(token, accessToken);
  }

  static getToken() {
    return window.localStorage.getItem(token);
  }

  static setRefreshToken(token) {
    window.localStorage.setItem(refreshToken, token);
  }

  static getRefreshToken() {
    return window.localStorage.getItem(refreshToken);
  }

  static setTokenType(accessTokenType) {
    window.localStorage.setItem(tokenType, accessTokenType);
  }

  static getTokenType() {
    return window.localStorage.getItem(tokenType);
  }

  static isAuthenticated() {
    return this.getToken() !== null;
  }
}
