import React, { Component } from 'react';
import { Col, FormGroup, FormControl, Button, NavItem, Nav, ControlLabel } from 'react-bootstrap';
import PropTypes from 'prop-types';
import QuestionList from './QuestionList';
import {
  TITLE_IS_REQUIRED,
} from './errors';

import './PageNavigator.scss';

export class PageNavigator extends Component {
  constructor(props) {
    super(props);
    let pages = this.props.pages.map(p => ({...p}));
    this.state = {
      editingPageNumber : 1,
      pages : pages,
    };
    this.errors = {
      pages : this.props.errors,
    };
  }

  componentWillReceiveProps = (props) => {
    let pages = props.pages.map(p => ({...p}));
    this.setState({
      pages : pages,
      editingPageNumber : props.editingPageNumber,
    });
    this.errors.pages = props.errors;
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
    this.survey.pages.splice(this.state.editingPageNumber - 1, 1);
    this.errors.pages.splice(this.state.editingPageNumber - 1, 1);
    this.setState({
      editingPageNumber: 1,
      pages : pages,
    });
    this.props.handleOnPagesUpdate(pages, this.errors);
    this.props.handleOnPageSwitch(1);
  }

  handleOnTitleChange = (event) => {
    let pages = this.state.pages.map(p => ({...p}));
    pages[this.state.editingPageNumber - 1].title = event.target.value;
    this.setState({ pages : pages });
    if(event.target.value.trim().length === 0) {
      this.errors.pages[this.state.editingPageNumber - 1].title = TITLE_IS_REQUIRED;
    } else {
      this.errors.pages[this.state.editingPageNumber - 1].title = null;
    }
    this.props.handleOnPagesUpdate(pages, this.errors);
  }

  handleOnQuestionsArraySave = (questions, errors) => {
    this.errors.pages[this.state.editingPageNumber - 1].questions = errors.questions;
    this.props.handleOnQuestionsArraySave(questions, this.errors);
  }

  render = () => {
    return (
      <div>
        <Nav bsStyle="tabs" justified>
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
        <div className="page-control">
          <FormGroup className="page-form-group" controlNumber="page" >
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
          <Button onClick={this.handleOnDeleteClick}>Delete</Button>
        </div>
        <QuestionList
          questions={this.state.pages[this.state.editingPageNumber - 1].questions}
          handleOnEditingQuestionNumberChange={this.props.handleOnEditingQuestionNumberChange}
          handleOnQuestionsArraySave={this.handleOnQuestionsArraySave}
          editingQuestionNumber={this.props.editingQuestionNumber}
          newEditingQuestionType={this.props.newEditingQuestionType}
          errors={this.errors.pages[this.state.editingPageNumber - 1].questions}
        />
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
