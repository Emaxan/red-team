import React from 'react';
import { connect } from 'react-redux';
import { Switch, Route } from 'react-router-dom';

import Routes from './routes';
import ItemSelector from './selectors/itemSelector';
import { Header, Footer, Sidebar } from './components';
import UserListContainer from '../users/UserListContainer';
import SignupContainer from '../auth/signup/SignupContainer';
import LoginContainer from '../auth/login/LoginContainer';
import {
  userIsAuthenticatedRedirect,
  userIsNotAuthenticatedRedirect,
  userIsAdminRedirect,
  userIsAuthenticated,
} from '../auth/auth';

import './App.scss';

const mapStateToProps = (state) => ({
  userName : state.auth.userInfo.userName,
  menuItems : ItemSelector(state),
});

const UserList = userIsAuthenticatedRedirect(userIsAdminRedirect(UserListContainer));
const Login = userIsNotAuthenticatedRedirect(LoginContainer);
const SignUp = userIsNotAuthenticatedRedirect(SignupContainer);
const SideBar = userIsAuthenticated(Sidebar);

const App = ({ userName, menuItems }) => (
  <div className="wrapper">
    <Header userName={userName} />
    <div className="container content">
      <SideBar menuItems={menuItems} />
      <main className="main">
        <Switch>
          <Route path={Routes.Users.path} component={UserList} />
          <Route path={Routes.SignUp.path} component={SignUp}/>
          <Route path={Routes.Login.path} component={Login} />
        </Switch>
      </main>
    </div>
    <Footer />
  </div>
);

App.propTypes = {
  ...Header.propTypes,
  ...Sidebar.propTypes,
  ...Footer.propTypes,
};

App.defaultProps = {
  userName : '',
};

export default connect(mapStateToProps, null, null, { pure: false })(App);
