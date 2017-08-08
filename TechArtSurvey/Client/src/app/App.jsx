import React, { Component } from 'react';
import { connect } from 'react-redux';
import { Switch, Route, Redirect } from 'react-router-dom';
import PropTypes from 'prop-types';

import Routes from './routesConstants';
import { Header } from './components/Header';
import { Footer } from './components/Footer';
import { Sidebar } from './components/Sidebar';
import UserListContainer from '../users/UserListContainer';
import SignupContainer from '../auth/signup/SignupContainer';
import LogInContainer from '../auth/login/LogInContainer';

import './App.scss';

function mapStateToProps(state) {
  return {
    isAuthenticated : state.auth.isAuthenticated,
  };
}

export class App extends Component {
  render() {
    return (
      <div className="wrapper">
        <Header authStatus={this.props.isAuthenticated ? true : true} />
        <div className="container content">
          {
            (this.props.isAuthenticated ? true : true) ? <Sidebar /> : ''
          }
          <main className="main">
            <Switch>
              <Route path={Routes.Users.path} component={UserListContainer} />
              <Route
                path={Routes.SignUp.path} render={
                  () => (
                    (this.props.isAuthenticated ? false : false) ?
                      <Redirect to={Routes.Main.path} /> :
                      <SignupContainer />
                  )
                }
              />
              <Route path={Routes.LogIn.path} component={LogInContainer} />
            </Switch>
          </main>
        </div>
        <Footer />
      </div>
    );
  }
}

App.propTypes = {
  isAuthenticated : PropTypes.bool.isRequired,
};

export default connect(mapStateToProps, null, null, { pure: false })(App);
