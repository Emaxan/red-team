import { createSelector } from 'reselect';

import Roles from '../roles';
import Routes from '../routesConstants';

const routesSelector = () => Routes;

const roleSelector = (state) => state.auth.role;

const getFilteredRoutes = (routeList, role) => {
  const filteredRoutes = [];

  for(const route in routeList) {
    if((routeList[route].access === Roles.USERS) || (routeList[route].access === role)) {
      filteredRoutes.push(routeList[route]);
    }
  }

  return filteredRoutes;
};

export default createSelector(
  routesSelector,
  roleSelector,
  getFilteredRoutes
);
