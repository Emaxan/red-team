import React from 'react';
import { connect } from 'react-redux';
import PropTypes from 'prop-types';

import { Header } from './components/Header';
import { Footer } from './components/Footer';
import { Sidebar } from './components/Sidebar';
import RouteWithSubRoutes from '../components/RouteWithSubRoutes';

import './App.scss';

function mapStateToProps(state) {
  return {
    isAuthenticated : state.auth.isAuthenticated,
  };
}

const App = ({ isAuthenticated, routes }) => (
  <div className="wrapper">
    <Header authStatus={isAuthenticated ? true : true} />
    <div className="container content">
      {
        (isAuthenticated ? true : true) ? <Sidebar /> : ''
      }
      <main className="main">
        {
          routes.map((route, i) => (
            <RouteWithSubRoutes key={i} {...route}/>
          ))
        }
      </main>
    </div>
    <Footer />
  </div>
);

App.propTypes = {
  isAuthenticated : PropTypes.bool.isRequired,
  routes : PropTypes.array.isRequired,
};

export default connect(mapStateToProps, null, null, { pure: false })(App);
