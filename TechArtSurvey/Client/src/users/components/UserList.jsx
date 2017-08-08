import React, { Component } from 'react';
import PropTypes from 'prop-types';

import { SearchBox } from './SearchBox';

export class UserList extends Component {
  handleOnBtnClick() {
    this.props.getUsers();
  }

  render() {
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
              <td>Actions</td>
            </tr>{
              this.props.filteredUserList.map((user) => (
                <tr key={user.Id} className="table-row">
                  <td>{user.Id}</td>
                  <td>{user.Name}</td>
                  <td>{user.Email}</td>
                  <td>{user.Password}</td>
                  <td></td>
                </tr>
              ))
            }
            <tr className="table-row">
              <td colSpan="5">Total users: {this.props.filteredUserList.length}</td>
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
};
