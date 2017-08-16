import React from 'react';
import CustomScroll from 'react-custom-scroll';
import { Switch, Route } from 'react-router-dom';
import PropTypes from 'prop-types';

import Routes from '../routes';
import UserListContainer from '../../users/UserListContainer';
import SignUpContainer from '../../auth/signUp/SignUpContainer';
import LoginContainer from '../../auth/login/LoginContainer';
import { AboutContainer } from '../../about/AboutContainer';
import {
  userIsAuthenticatedRedirect,
  userIsNotAuthenticatedRedirect,
  userIsAdminRedirect,
} from '../../auth/auth';
import { NotFound } from '../../error/NotFound';
import { Forbidden } from '../../error/Forbidden';
import { Home } from '../../home/Home';

import './AppContent.scss';

const UserList = userIsAuthenticatedRedirect(userIsAdminRedirect(UserListContainer));
const Login = userIsNotAuthenticatedRedirect(LoginContainer);
const SignUp = userIsNotAuthenticatedRedirect(SignUpContainer);

const AppContent = ({ className }) => (
  <div className={'main ' + className}>
    <CustomScroll flex="1">
      <Switch>
        <Route path={Routes.Forbidden.path} component={Forbidden} />
        <Route exact path={Routes.Main.path} component={Home}/>
        <Route path={Routes.Users.path} component={UserList} />
        <Route path={Routes.SignUp.path} component={SignUp}/>
        <Route path={Routes.Login.path} component={Login} />
        <Route path={Routes.About.path} component={AboutContainer} />
        <Route component={NotFound}/>
      </Switch>
    </CustomScroll>
  </div>
);

AppContent.propTypes = {
  className : PropTypes.string,
};

export default AppContent;
