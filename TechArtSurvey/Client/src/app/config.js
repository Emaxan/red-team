import urljoin from 'url-join';

import appRoutes from './routes';

export const GOOGLE_API_KEY = 'AIzaSyDnfyOejhKXKrJ7GIVWDV8Odseqdcwg0k0';

const SERVER_ROOT_URL = 'http://localhost:3000';

export const API_URL = urljoin(SERVER_ROOT_URL, '/api');
export const AUTH_URL = SERVER_ROOT_URL;
export const RESET_PASSWORD_CALLBACK_URL = urljoin(SERVER_ROOT_URL, appRoutes.ResetPassword.path);
