import { Record } from 'immutable';
import { handleActions } from 'redux-actions';

const LOCATION_CHANGE = '@@router/LOCATION_CHANGE';

const locationInitialState = Record({
  hash : '',
  key : '',
  pathname : '',
  search : '',
  state : undefined,
});

const routerInitialState = Record({
  location: new locationInitialState(),
});

const initialState = new routerInitialState();

export const routerReducer = handleActions({
  [LOCATION_CHANGE] : (state, action) =>
    state.set('location', state.get('location')
      .set('hash', action.payload.hash)
      .set('key', action.payload.key)
      .set('pathname', action.payload.pathname)
      .set('search', action.payload.search)
      .set('state', action.payload.state)),
}, initialState);
