import React, { Component } from 'react';
import { Panel, Nav, NavItem } from 'react-bootstrap';
import PropTypes from 'prop-types';

export class QuestionTypesPanel extends Component {
  handleOnSelect = (event) => {
    this.props.handleOnTypeChange(event);
  }

  render = () => {
    return (
      <Panel header="Question types" bsStyle="primary">
        <Nav bsStyle="pills" stacked activeKey={2} onSelect={this.handleOnSelect}>
          {
            this.props.questionTypesArray.map((type) => (
              <NavItem key={type.id} eventKey={type.name} >
                {type.name}
              </NavItem>
            ))
          }
        </Nav>
      </Panel >
    );
  }
}

QuestionTypesPanel.propTypes = {
  questionTypesArray : PropTypes.array.isRequired,
  handleOnTypeChange: PropTypes.func.isRequired,
};
