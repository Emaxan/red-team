import { render } from 'react-dom';
import React from 'react';
import { applyMiddleware } from 'redux';
import { Provider } from 'react-redux';
import thunk from 'redux-thunk';
import logger from 'redux-logger';
import { ConnectedRouter, routerMiddleware as createRouterMiddleware } from 'react-router-redux';
import createHistory from 'history/createBrowserHistory';

import configureStore from './app/configureStore';
import { authMiddleware } from './auth/middlewares/authMiddleware';
import routes from './app/routes';
import RouteWithSubRoutes from './components/RouteWithSubRoutes';

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
      <div>
        {
          routes.map((route, i) => (
            <RouteWithSubRoutes key={i} {...route}/>
          ))
        }
      </div>
    </ConnectedRouter>
  </Provider>,
  document.getElementById('container')
);
