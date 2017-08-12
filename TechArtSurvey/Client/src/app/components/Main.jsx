import React from 'react';
import CustomScroll from 'react-custom-scroll';
import { Switch, Route } from 'react-router-dom';
import PropTypes from 'prop-types';

import Routes from '../routesConstants';
import UserListContainer from '../../users/UserListContainer';
import SignupContainer from '../../auth/signup/SignupContainer';
import LogInContainer from '../../auth/login/LogInContainer';
import {
  userIsAuthenticatedRedirect,
  userIsNotAuthenticatedRedirect,
  userIsAdminRedirect,
} from '../../auth/auth';

import './Main.scss';

const UserList = userIsAuthenticatedRedirect(userIsAdminRedirect(UserListContainer));
const LogIn = userIsNotAuthenticatedRedirect(LogInContainer);
const SignUp = userIsNotAuthenticatedRedirect(SignupContainer);

const Main = ({ className }) => (
  <div className={'main ' + className}>
    <CustomScroll flex="1">
      <Switch>
        <Route path={Routes.Users.path} component={UserList} />
        <Route path={Routes.SignUp.path} component={SignUp}/>
        <Route path={Routes.LogIn.path} component={LogIn} />
      </Switch>
    </CustomScroll>
  </div>
);

Main.propTypes = {
  className : PropTypes.string,
};

export default Main;

