import React from 'react';
import locationHelperBuilder from 'redux-auth-wrapper/history4/locationHelper';
import { connectedRouterRedirect } from 'redux-auth-wrapper/history4/redirect';
import connectedAuthWrapper from 'redux-auth-wrapper/connectedAuthWrapper';

import Routes from '../app/routesConstants';
import Roles from '../app/roles';

const locationHelper = locationHelperBuilder({});

const userIsAuthenticatedDefaults = {
  authenticatedSelector: state => state.auth.isAuthenticated,
  wrapperDisplayName: 'UserIsAuthenticated',
};

export const userIsAuthenticated = connectedAuthWrapper(userIsAuthenticatedDefaults);

export const userIsAuthenticatedRedir = connectedRouterRedirect({
  ...userIsAuthenticatedDefaults,
  AuthenticatingComponent: <div>Loading...</div>,
  redirectPath: Routes.LogIn.path,
});

export const userIsAdminRedir = connectedRouterRedirect({
  redirectPath: Routes.Main.path,
  allowRedirectBack: false,
  authenticatedSelector: state => state.auth.isAuthenticated && state.auth.role === Roles.ADMIN,
  wrapperDisplayName: 'UserIsAdmin',
});

const userIsNotAuthenticatedDefaults = {
  authenticatedSelector: state => !state.auth.isAuthenticated,
  wrapperDisplayName: 'UserIsNotAuthenticated',
};

export const userIsNotAuthenticated = connectedAuthWrapper(userIsNotAuthenticatedDefaults);

export const userIsNotAuthenticatedRedir = connectedRouterRedirect({
  ...userIsNotAuthenticatedDefaults,
  redirectPath: (state, ownProps) => locationHelper.getRedirectQueryParam(ownProps) || Routes.Main.path,
  allowRedirectBack: false,
});