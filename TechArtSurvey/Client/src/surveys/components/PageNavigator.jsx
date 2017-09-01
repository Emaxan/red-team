import React, { Component } from 'react';
import { Col, FormGroup, FormControl, Button, NavItem, Nav, ControlLabel } from 'react-bootstrap';
import PropTypes from 'prop-types';
import QuestionList from './QuestionList';

import {
  validateTitle,
} from '../../utils/validation/questionValidation';

import './PageNavigator.scss';

export class PageNavigator extends Component {
  constructor(props) {
    super(props);
    let pages = this.props.pages.map(p => ({...p}));
    this.state = {
      editingPageNumber : 1,
      pages : pages,
    };
    this.errors = { ...this.props.errors };

    this.validationStates = {
      title : null,
    };
  }

  componentWillReceiveProps = (props) => {
    let pages = props.pages.map(p => ({...p}));
    this.setState({
      pages : pages,
      editingPageNumber : props.editingPageNumber,
    });
    this.errors = props.errors;
  }

  handleOnPageSwitch = (pageNumber) => {
    if(pageNumber == this.state.editingPageNumber) {
      return;
    }
    this.setState({ editingPageNumber : pageNumber });
    this.props.handleOnPageSwitch(pageNumber);
  }

  handleOnDeleteClick = () => {
    let pages = this.state.pages.map(p => ({...p}));
    if(pages.length == 1) {
      return;
    }
    pages.splice(this.state.editingPageNumber - 1, 1);
    this.errors.splice(this.state.editingPageNumber - 1, 1);
    this.setState({
      editingPageNumber: 1,
      pages : pages,
    });
    this.props.handleOnPagesUpdate(pages, this.errors);
    this.props.handleOnPageSwitch(1);
  }

  handleOnTitleChange = (event) => {
    let title = event.target.value;

    this.setValidationState('title', validateTitle(title));

    let pages = this.state.pages.map(p => ({...p}));
    pages[this.state.editingPageNumber - 1].title = title;
    this.setState({ pages : pages });

    this.props.handleOnPagesUpdate(pages, this.errors);
  }

  handleOnQuestionsArraySave = (questions, errors) => {
    this.errors[this.state.editingPageNumber - 1].questions = errors;
    this.props.handleOnQuestionsArraySave(questions, this.errors);
  }

  setValidationState = (fieldName, validationInfo) => {
    if (validationInfo.isValid) {
      this.errors[this.state.editingPageNumber - 1][fieldName] = null;
      this.validationStates[fieldName] = 'success';
    } else {
      this.errors[this.state.editingPageNumber - 1][fieldName] = validationInfo.errors[0].message;
      this.validationStates[fieldName] = 'error';
    }
  }

  render = () => {
    return (
      <div>
        <Nav bsStyle="tabs" activeKey={this.state.editingPageNumber} justified>
          {
            this.state.pages.map((page, index) => (
              <NavItem key={index} eventKey={index + 1} onSelect={this.handleOnPageSwitch}>
                {
                  (page.title && page.title.trim().length > 0)
                    ? <span>{page.title}</span>
                    : <span>Page {index + 1}</span>
                }
              </NavItem>
            ))
          }
        </Nav>
        <div className="page">
          <div className="page-control">
            <FormGroup className="page-form-group">
              <Col componentClass={ControlLabel} sm={2}>
                New page
              </Col>
              <Col sm={10}>
                <FormControl
                  type="text"
                  value={this.state.pages[this.state.editingPageNumber - 1].title}
                  placeholder="Enter page title"
                  onChange={this.handleOnTitleChange}
                />
              </Col>
            </FormGroup>
            <Button className="page-delete" onClick={this.handleOnDeleteClick}>Delete</Button>
          </div>
          <QuestionList
            questions={this.state.pages[this.state.editingPageNumber - 1].questions}
            handleOnEditingQuestionNumberChange={this.props.handleOnEditingQuestionNumberChange}
            handleOnQuestionsArraySave={this.handleOnQuestionsArraySave}
            editingQuestionNumber={this.props.editingQuestionNumber}
            newEditingQuestionType={this.props.newEditingQuestionType}
            errors={this.errors[this.state.editingPageNumber - 1].questions}
          />
        </div>
      </div>
    );
  }
}

PageNavigator.propTypes = {
  editingPageNumber : PropTypes.number.isRequired,
  pages : PropTypes.array.isRequired,
  errors : PropTypes.array.isRequired,
  handleOnPageSwitch : PropTypes.func.isRequired,
  handleOnPagesUpdate : PropTypes.func.isRequired,
  newEditingQuestionType : PropTypes.string.isRequired,
  editingQuestionNumber : PropTypes.number.isRequired,
  handleOnQuestionsArraySave : PropTypes.func.isRequired,
  handleOnEditingQuestionNumberChange : PropTypes.func.isRequired,
};
