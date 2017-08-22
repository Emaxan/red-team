import React from 'react';
import locationHelperBuilder from 'redux-auth-wrapper/history4/locationHelper';
import { connectedRouterRedirect } from 'redux-auth-wrapper/history4/redirect';
import connectedAuthWrapper from 'redux-auth-wrapper/connectedAuthWrapper';

import Routes from '../app/routes';
import Role from '../app/role';

const locationHelper = locationHelperBuilder({});

const userIsAuthenticatedDefaults = {
  authenticatedSelector: state => state.auth.isAuthenticated,
  wrapperDisplayName: 'UserIsAuthenticated',
};

export const userIsAuthenticated = connectedAuthWrapper(userIsAuthenticatedDefaults);

export const userIsAuthenticatedRedirect = connectedRouterRedirect({
  ...userIsAuthenticatedDefaults,
  AuthenticatingComponent: <div>Loading...</div>,
  redirectPath: Routes.Login.path,
});

export const userIsAdminRedirect = connectedRouterRedirect({
  redirectPath: Routes.Forbidden.path,
  allowRedirectBack: false,
  authenticatedSelector: state => state.auth.isAuthenticated && state.auth.userInfo.role === Role.ADMIN,
  wrapperDisplayName: 'UserIsAdmin',
});

const userIsNotAuthenticatedDefaults = {
  authenticatedSelector: state => !state.auth.isAuthenticated,
  wrapperDisplayName: 'UserIsNotAuthenticated',
};

export const userIsNotAuthenticated = connectedAuthWrapper(userIsNotAuthenticatedDefaults);

export const userIsNotAuthenticatedRedirect = connectedRouterRedirect({
  ...userIsNotAuthenticatedDefaults,
  redirectPath: (state, ownProps) => locationHelper.getRedirectQueryParam(ownProps) || Routes.Main.path,
  allowRedirectBack: false,
});