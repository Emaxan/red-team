import React from 'react';
import { Route, Redirect } from 'react-router-dom';

const RouteWithSubRoutes = (route) => {
  if(route.redirect)
  {
    return (<Route exact path={route.from} render={() => <Redirect to={route.to} />} />);
  } else {
    return (
      <Route path={route.path} render={props => (
        <route.component {...props} routes={route.routes}/>
      )}/>
    );
  }
};

export default RouteWithSubRoutes;
