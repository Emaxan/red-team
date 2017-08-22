import { createSelector } from 'reselect';

import SidebarDisplay from '../sidebarDisplay';
import Routes from '../routes';

const routesSelector = () => Routes;

const roleSelector = (state) => state.auth.userInfo.role;

const getFilteredRoutes = (routeList, role) => {
  const filteredRoutes = [];

  for(const route in routeList) {
    if((routeList[route].display === SidebarDisplay.ANY) || (routeList[route].display === role)) {
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
