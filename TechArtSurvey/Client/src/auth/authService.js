const token = 'auth.token';
const refreshToken = 'auth.refreshToken';
const tokenType = 'auth.tokenType';
const userRole = 'auth.userRole';
const userName = 'auth.userName';

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

  static setUserName(name) {
    window.localStorage.setItem(userName, name);
  }

  static getUserName() {
    return window.localStorage.getItem(userName);
  }

  static setUserRole(role) {
    window.localStorage.setItem(userRole, role);
  }

  static getUserRole() {
    return window.localStorage.getItem(userRole);
  }

  static isAuthenticated() {
    return this.getToken() !== null;
  }

  static clearUserInfo() {
    window.localStorage.removeItem(token);
    window.localStorage.removeItem(refreshToken);
    window.localStorage.removeItem(tokenType);
    window.localStorage.removeItem(userName);
    window.localStorage.removeItem(userRole);
  }
}
