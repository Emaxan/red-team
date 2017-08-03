import { API_URL } from '../app/config';

export const getUsers = () => fetch(`${API_URL}/users`);
