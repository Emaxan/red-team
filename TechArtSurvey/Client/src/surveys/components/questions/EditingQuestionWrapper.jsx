import React, { Component } from 'react';
import { Panel, Button, Checkbox, ButtonGroup } from 'react-bootstrap';
import PropTypes from 'prop-types';

import { questionsFactory } from '../questionsFactory';

import './EditingQuestionWrapper.scss';

export class EditingQuestionWrapper extends Component {
  constructor(props) {
    super(props);

    this.state = {
      question : {...this.props.question},
    };
  }

  componentWillReceiveProps = (props) => {
    let type = props.question.type;
    this.setState({ question : { ...this.state.question, type : type } });
  }

  handleOnQuestionUpdate = (question) => {
    let metaInfo = [];
    question.metaInfo.map(m => {
      if(m && m.trim().length > 0) {
        metaInfo.push(m.trim());
      }
    });
    question.metaInfo = metaInfo;
    this.setState({ question: {...question} });
  }

  handleOnSaveClick = () => {
    let question = {...this.state.question};
    let metaInfo = [];
    question.title = question.title.trim();
    question.metaInfo.map(m => {
      if(m && m.trim().length > 0) {
        metaInfo.push(m.trim());
      }
    });
    question.metaInfo = metaInfo;
    this.setState({ question: {...question} });
    this.props.handleOnQuestionSave({...question});
  }

  handleOnCancelClick = () => {
    this.props.handleOnEditingQuestionNumberChange(-1);
  }

  handleOnRequiredClick = () => {
    let { question } = this.state;
    question.isRequired = !question.isRequired;
    this.setState({ question: {...question} });
  }

  handleOnDeleteClick = () => {
    this.props.handleOnDeleteClick();
  }

  render = () =>
    <Panel className="edit-question">
      <div className="top-actions">
        <Checkbox onClick={this.handleOnRequiredClick} checked={this.state.question.isRequired} className="top-actions__required">
          Required
        </Checkbox>
        <Button onClick={this.handleOnDeleteClick}>
          Delete
        </Button>
      </div>
      {
        questionsFactory[this.state.question.type](
          this.state.question,
          this.handleOnQuestionUpdate,
          {
            editing : this.props.editing,
          },
        )
      }
      <ButtonGroup className="bottom-actions">
        <Button onClick={this.handleOnSaveClick}>
          Save
        </Button>
        <Button onClick={this.handleOnCancelClick}>
          Cancel
        </Button>
      </ButtonGroup>
    </Panel>
}

EditingQuestionWrapper.propTypes = {
  handleOnQuestionSave : PropTypes.func.isRequired,
  question : PropTypes.object.isRequired,
  handleOnEditingQuestionNumberChange : PropTypes.func.isRequired,
  handleOnDeleteClick : PropTypes.func.isRequired,
  editing : PropTypes.bool.isRequired,
};
