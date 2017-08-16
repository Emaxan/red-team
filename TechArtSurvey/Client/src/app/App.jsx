import React, { Component } from 'react';
import { connect } from 'react-redux';

import ItemSelector from './selectors/itemSelector';
import { Footer, Sidebar, AppContent } from './components';
import Header from './components/header/Header';
import {
  userIsAuthenticated,
} from '../auth/auth';

import './App.scss';

const mapStateToProps = (state) => ({
  userName : state.auth.userInfo.userName,
  email : state.auth.userInfo.email,
  menuItems : ItemSelector(state),
});

const SideBar = userIsAuthenticated(Sidebar);

class App extends Component {
  componentDidUpdate(){
    $.material.init({validate : false});
  }

  render() {
    return (
      <div className="wrapper">
        <Header userName={this.props.userName} email={this.props.email} />
        <div className="content">
          <SideBar menuItems={this.props.menuItems} />
          <AppContent className="app-content" />
        </div>
        <Footer />
      </div>
    );
  }
}

App.propTypes = {
  ...Header.propTypes,
  ...Sidebar.propTypes,
  ...AppContent.propTypes,
  ...Footer.propTypes,
};

App.defaultProps = {
  userName : '',
  email : '',
};

export default connect(mapStateToProps, null, null, { pure: false })(App);
