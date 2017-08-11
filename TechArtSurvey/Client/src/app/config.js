import urljoin from 'url-join';

const SERVER_ROOT_URL = 'http://localhost:3000';
export const API_URL = urljoin(SERVER_ROOT_URL, '/api');
export const AUTH_URL = SERVER_ROOT_URL;
