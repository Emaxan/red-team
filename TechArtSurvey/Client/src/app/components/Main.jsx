import React from 'react';
import CustomScroll from 'react-custom-scroll';
import { Switch, Route } from 'react-router-dom';
import PropTypes from 'prop-types';

import Routes from '../routes';
import UserListContainer from '../../users/UserListContainer';
import SignupContainer from '../../auth/signup/SignupContainer';
import LoginContainer from '../../auth/login/LoginContainer';
import {
  userIsAuthenticatedRedirect,
  userIsNotAuthenticatedRedirect,
  userIsAdminRedirect,
} from '../../auth/auth';

import './Main.scss';

const UserList = userIsAuthenticatedRedirect(userIsAdminRedirect(UserListContainer));
const Login = userIsNotAuthenticatedRedirect(LoginContainer);
const SignUp = userIsNotAuthenticatedRedirect(SignupContainer);

const Main = ({ className }) => (
  <div className={'main ' + className}>
    <CustomScroll flex="1">
      <Switch>
        <Route path={Routes.Users.path} component={UserList} />
        <Route path={Routes.SignUp.path} component={SignUp}/>
        <Route path={Routes.Login.path} component={Login} />
      </Switch>
    </CustomScroll>
  </div>
);

Main.propTypes = {
  className : PropTypes.string,
};

export default Main;

