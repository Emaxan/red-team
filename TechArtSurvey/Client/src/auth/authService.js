const token = 'auth.token';

export default class AuthService {
  static setToken(accessToken) {
    window.localStorage.setItem(token, accessToken);
  }

  static getToken() {
    return window.localStorage.getItem(token);
  }

  static isAuthenticated() {
    return this.getToken() !== null;
  }
}
