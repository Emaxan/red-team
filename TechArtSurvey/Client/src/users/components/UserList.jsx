import React, { Component } from 'react';
import PropTypes from 'prop-types';

import { SearchBox } from './SearchBox';
import { Spinner } from '../../components/Spinner';

export class UserList extends Component {
  handleOnBtnClick = () => {
    this.props.getUsers();
  }

  render = () => {
    if (this.props.isFetching) {
      return <Spinner />;
    }

    return (
      <div>
        <h2>Users</h2>
        <SearchBox setFilter={this.props.setFilter} />
        <table>
          <tbody>
            <tr className="table-row">
              <td>Id</td>
              <td>Name</td>
              <td>Email</td>
              <td>Password</td>
              <td>Role</td>
              <td>Actions</td>
            </tr>{
              this.props.filteredUserList.map((user) => (
                <tr key={user.id} className="table-row">
                  <td>{user.id}</td>
                  <td>{user.userName}</td>
                  <td>{user.email}</td>
                  <td>{user.password}</td>
                  <td>{user.role.name}</td>
                  <td></td>
                </tr>
              ))
            }
            <tr className="table-row">
              <td colSpan="6">Total users: {this.props.filteredUserList.length}</td>
            </tr>
          </tbody>
        </table>
        <button onClick={this.handleOnBtnClick.bind(this)}>Update</button>
      </div>
    );
  }
}

UserList.propTypes = {
  filteredUserList : PropTypes.array.isRequired,
  getUsers : PropTypes.func.isRequired,
  setFilter : PropTypes.func.isRequired,
  isFetching : PropTypes.bool.isRequired,
};
