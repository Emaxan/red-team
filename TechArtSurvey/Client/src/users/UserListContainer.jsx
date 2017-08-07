import React, { Component } from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import PropTypes from 'prop-types';
import ImmutablePropTypes from 'react-immutable-proptypes';

import { getUsers, setFilter } from './actions';
import { UserList } from './UserList';
import FilteredUsers from './selectors/filteredUsers';

const mapStateToProps = (state) => ({
  userList : state.users.userList,
  fetching : state.users.fetching,
  filteredUserList : FilteredUsers(state),
});

const mapDispatchToProps = (dispatch) => ({
  actions : bindActionCreators({ getUsers }, dispatch),
  filter : bindActionCreators({ setFilter }, dispatch),
});

export class UserListContainer extends Component {
  render() {
    return (
      <div className="user-list">
        <UserList
          userList={this.props.userList}
          filteredUserList={this.props.filteredUserList}
          getUsers={this.props.actions.getUsers}
          setFilter={this.props.filter.setFilter}
        />
        {
          this.props.fetching ?
            <p>Updating...</p> :
            <p />
        }
      </div>
    );
  }
}

UserListContainer.propTypes = {
  actions : PropTypes.object.isRequired,
  filter : PropTypes.object.isRequired,
  fetching : PropTypes.bool.isRequired,
  userList : ImmutablePropTypes.list.isRequired,
  filteredUserList : PropTypes.array.isRequired,
};

export default connect(mapStateToProps, mapDispatchToProps)(UserListContainer);
