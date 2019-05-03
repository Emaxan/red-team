import jwt_decode from 'jwt-decode';

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

  static getUserInfo() {
    const token = this.getToken();

    if (!token) return { };

    const jwt = jwt_decode(this.getToken());
    return {
      userName : jwt.unique_name,
      email : jwt.email,
      role : jwt.role,
    };
  }

  static isAuthenticated() {
    return this.getToken() !== null;
  }

  static clearUserInfo() {
    window.localStorage.removeItem(token);
    window.localStorage.removeItem(refreshToken);
    window.localStorage.removeItem(tokenType);
  }
}
