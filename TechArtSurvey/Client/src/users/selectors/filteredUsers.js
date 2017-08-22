import { createSelector } from 'reselect';
import { _ } from 'underscore';

const userListSelector = (state) => state.users
  .get('userList')
  .toArray();

const filterString = (state) => state.users
  .get('filterInput');

const getFilteredUsers = (userList, input) => {
  const filteredUsers = _.filter(
    userList,
    (user) => user.userName
      .toLowerCase()
      .includes(input.toLowerCase()),
  );

  return filteredUsers;
};

export default createSelector(
  userListSelector,
  filterString,
  getFilteredUsers,
);
