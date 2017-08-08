import React, { Component } from 'react';
import { connect } from 'react-redux';

import { getUsers, setFilter } from './actions';
import { UserList } from './components/UserList';
import FilteredUsers from './selectors/filteredUsers';

const mapStateToProps = (state) => ({
  userList : state.users.userList,
  filteredUserList : FilteredUsers(state),
});

const mapDispatchToProps = {
  getUsers,
  setFilter,
};

export class UserListContainer extends Component {
  render() {
    return (
      <div className="user-list">
        <UserList
          filteredUserList={this.props.filteredUserList}
          getUsers={this.props.getUsers}
          setFilter={this.props.setFilter}
        />
      </div>
    );
  }
}

UserListContainer.propTypes = {
  ...UserList.propTypes,
};

export default connect(mapStateToProps, mapDispatchToProps)(UserListContainer);
