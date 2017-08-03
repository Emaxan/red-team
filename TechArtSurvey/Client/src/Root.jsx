import { render } from 'react-dom';
import React from 'react';
import { applyMiddleware } from 'redux';
import { Provider } from 'react-redux';
import thunk from 'redux-thunk';
import logger from 'redux-logger';
import { ConnectedRouter, routerMiddleware as createRouterMiddleware } from 'react-router-redux';
import createHistory from 'history/createBrowserHistory';
import './bootstrap/bootstrap';

import configureStore from './app/configureStore';
import App from './app/App';
import { authMiddleware } from './auth/middlewares/authMiddleware';

import './bootstrap/bootstrap.scss';

const history = createHistory();

const routerMiddleware = createRouterMiddleware(history);

const store = configureStore({
  middleware : applyMiddleware(
    thunk,
    logger,
    routerMiddleware,
    authMiddleware
  ),
});

render(
  <Provider store={store}>
    <ConnectedRouter history={history}>
      <App />
    </ConnectedRouter>
  </Provider>,
  document.getElementById('container')
);
