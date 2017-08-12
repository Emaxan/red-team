import React from 'react';
import { connect } from 'react-redux';

import ItemSelector from './selectors/itemSelector';
import { Header, Footer, Sidebar, Main } from './components';
import {
  userIsAuthenticated,
} from '../auth/auth';

import './App.scss';

const mapStateToProps = (state) => ({
  userName : state.auth.userInfo.userName,
  menuItems : ItemSelector(state),
});

const SideBar = userIsAuthenticated(Sidebar);

const App = ({ userName, menuItems }) => (
  <div className="wrapper">
    <Header userName={userName} />
    <div className="container content">
      <SideBar menuItems={menuItems} />
      <Main className="main" />
    </div>
    <Footer />
  </div>
);

App.propTypes = {
  ...Header.propTypes,
  ...Sidebar.propTypes,
  ...Main.propTypes,
  ...Footer.propTypes,
};

App.defaultProps = {
  userName : '',
};

export default connect(mapStateToProps, null, null, { pure: false })(App);
