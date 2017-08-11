import { createSelector } from 'reselect';

import Role from '../role';
import Routes from '../routesConstants';

const routesSelector = () => Routes;

const roleSelector = (state) => state.auth.userInfo.role;

const getFilteredRoutes = (routeList, role) => {
  const filteredRoutes = [];

  for(const route in routeList) {
    if((routeList[route].access === Role.ANY) || (routeList[route].access === role)) {
      filteredRoutes.push(routeList[route]);
    }
  }

  return filteredRoutes;
};

export default createSelector(
  routesSelector,
  roleSelector,
  getFilteredRoutes,
);
