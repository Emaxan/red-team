import React from 'react';
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

const UserListContainer = ({ filteredUserList, getUsers, setFilter }) => (
  <div className="user-list">
    <UserList
      filteredUserList={filteredUserList}
      getUsers={getUsers}
      setFilter={setFilter}
    />
  </div>
);

UserListContainer.propTypes = {
  ...UserList.propTypes,
};

export default connect(mapStateToProps, mapDispatchToProps)(UserListContainer);
