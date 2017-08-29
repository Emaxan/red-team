import React, { Component } from 'react';
import { Panel, Nav, NavItem } from 'react-bootstrap';
import PropTypes from 'prop-types';

export class QuestionTypesPanel extends Component {
  constructor(props) {
    super(props);
    this.state = {
      editingQuestionType : this.props.editingQuestionType,
    };
  }

  componentWillReceiveProps = (props) => {
    this.setState({ editingQuestionType : props.editingQuestionType });
  }

  handleOnSelect = (type) => {
    this.setState({ editingQuestionType : type });
    this.props.handleOnTypeChange(type);
  }

  render = () => {
    return (
      <Panel header="Question types" bsStyle="primary">
        <Nav bsStyle="pills" stacked activeKey={this.state.editingQuestionType} onSelect={this.handleOnSelect}>
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
  handleOnTypeChange : PropTypes.func.isRequired,
  editingQuestionType : PropTypes.string.isRequired,
};
