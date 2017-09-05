import { render } from 'react-dom';
import React from 'react';
import { applyMiddleware } from 'redux';
import { Provider } from 'react-redux';
import thunk from 'redux-thunk';
import logger from 'redux-logger';
import { ConnectedRouter, routerMiddleware as createRouterMiddleware } from 'react-router-redux';
import createHistory from 'history/createBrowserHistory';

import configureStore from './app/configureStore';
import App from './app/App';
import { authMiddleware } from './auth/authMiddleware';
import { loginMiddleware } from './auth/login/loginMiddleware';
import { syncUserToken } from './auth/actions';
import './bootstrap/bootstrap.js';

import './bootstrap/bootstrap.scss';

const history = createHistory();

const routerMiddleware = createRouterMiddleware(history);

const store = configureStore({
  middleware : applyMiddleware(
    thunk,
    logger,
    routerMiddleware,
    authMiddleware,
    loginMiddleware,
  ),
});

window.addEventListener('storage', () => store.dispatch(syncUserToken()));

render(
  <Provider store={store}>
    <ConnectedRouter history={history}>
      <App />
    </ConnectedRouter>
  </Provider>,
  document.getElementById('container'),
);
