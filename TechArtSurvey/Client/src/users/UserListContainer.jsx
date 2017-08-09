import React from 'react';
import { connect } from 'react-redux';

import { getUsers, setFilter } from './actions';
import { UserList } from './components/UserList';
import FilteredUsers from './selectors/filteredUsers';

const mapStateToProps = (state) => ({
  userList : state.users.userList,
  filteredUserList : FilteredUsers(state),
  accessToken : state.auth.token,
  tokenType : state.auth.tokenType,
});

const mapDispatchToProps = {
  getUsers,
  setFilter,
};
const UserListContainer = ({ filteredUserList, getUsers, setFilter, accessToken, tokenType }) => (
  <div className="user-list">
    <UserList
      filteredUserList={filteredUserList}
      getUsers={getUsers}
      setFilter={setFilter}
      accessToken={accessToken}
      tokenType={tokenType}
    />
  </div>
);

UserListContainer.propTypes = {
  ...UserList.propTypes,
};

export default connect(mapStateToProps, mapDispatchToProps)(UserListContainer);
