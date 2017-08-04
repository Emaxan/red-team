import React, { Component } from 'react';
import { connect } from 'react-redux';
import { Switch, Route } from 'react-router-dom';
import PropTypes from 'prop-types';

import Routes from './routesConstants';
import { Header } from './components/Header';
import { Footer } from './components/Footer';
import { Sidebar } from './components/Sidebar';
import UserListContainer from '../users/UserListContainer';
import { AboutContainer } from '../about/AboutContainer';

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
              <Route path={Routes.About.path} component={AboutContainer} />
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
