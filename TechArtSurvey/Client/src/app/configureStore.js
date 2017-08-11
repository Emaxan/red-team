import { createStore } from 'redux';

import combinedReducer from './reducer';

export default function configureStore({ initialState, middleware }) {
  const store = createStore(
    combinedReducer,
    initialState,
    middleware,
  );

  if (module.hot) {
    module.hot.accept(combinedReducer, () => store.replaceReducer(combinedReducer));
  }

  return store;
}
