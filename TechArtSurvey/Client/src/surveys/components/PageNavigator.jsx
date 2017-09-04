import React, { Component } from 'react';
import { Col, FormGroup, FormControl, Glyphicon, NavItem, Nav, ControlLabel } from 'react-bootstrap';
import PropTypes from 'prop-types';
import QuestionList from './QuestionList';

import {
  validateTitle,
} from '../../utils/validation/commonValidation';
import Page from '../models/Page';
import PageErrors from '../models/PageErrors';
import { isPageValid } from './service';

import './PageNavigator.scss';

export class PageNavigator extends Component {
  constructor(props) {
    super(props);
    let pages = this.props.pages.map(p => p.getCopy());
    this.state = {
      editingPageNumber : 1,
      pages : pages,
    };

    this.errors = this.props.errors.map(e => e.getCopy());

    this.validationStates = {
      title : null,
    };
  }

  componentWillReceiveProps = (props) => {
    let pages = props.pages.map(p => p.getCopy());
    this.setState({
      pages : pages,
      editingPageNumber : props.editingPageNumber,
    });
    this.errors = props.errors.map(e => e.getCopy());
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

  handleOnPageSwitch = (pageNumber) => {
    if(pageNumber == this.state.editingPageNumber) {
      return;
    }
    this.setState({ editingPageNumber : pageNumber });
    this.props.handleOnPageSwitch(pageNumber);
  }

  handleOnDeleteClick = () => {
    let pages = this.state.pages.map(p => p.getCopy());
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

    let pages = this.state.pages.map(p => p.getCopy());
    pages[this.state.editingPageNumber - 1].title = title;
    this.setState({ pages : pages });

    this.props.handleOnPagesUpdate(pages, this.errors);
  }

  handleOnQuestionsArraySave = (questions, errors) => {
    this.errors[this.state.editingPageNumber - 1].questions = errors;
    this.props.handleOnQuestionsArraySave(questions, this.errors);
  }

  getClassName = (index) => {
    const errorTab = 'error-tab';
    if(!isPageValid(this.errors[index])) {
      return errorTab;
    }

    return '';
  }

  render = () => {
    return (
      <div>
        <Nav bsStyle="tabs" activeKey={this.state.editingPageNumber} justified>
          {
            this.state.pages.map((page, index) => (
              <NavItem key={index} eventKey={index + 1} onSelect={this.handleOnPageSwitch}>
                <div className={this.getClassName(index)}>
                  {
                    (page.title && page.title.trim().length > 0)
                      ? <span>{page.title}</span>
                      : <span>Page {index + 1}</span>
                  }
                </div>
              </NavItem>
            ))
          }
        </Nav>
        <div className="page">
          <div className="page-control">
            <FormGroup className="page-form-group" validationState={this.validationStates.title}>
              <Col componentClass={ControlLabel} sm={2}>
                New page
              </Col>
              <Col sm={10}>
                <ControlLabel>
                  {this.errors[this.state.editingPageNumber - 1].title || 'Page\'s title'}
                </ControlLabel>
                <FormControl
                  type="text"
                  value={this.state.pages[this.state.editingPageNumber - 1].title}
                  onChange={this.handleOnTitleChange}
                />
              </Col>
            </FormGroup>
            <Glyphicon glyph="trash" role="button" title="Remove page" onClick={this.handleOnDeleteClick} className="page-delete"/>
          </div>
          <QuestionList
            questions={this.state.pages[this.state.editingPageNumber - 1].questions}
            handleOnEditingQuestionNumberChange={this.props.handleOnEditingQuestionNumberChange}
            handleOnQuestionsArraySave={this.handleOnQuestionsArraySave}
            editingQuestionNumber={this.props.editingQuestionNumber}
            newEditingQuestionType={this.props.newEditingQuestionType}
            errors={this.errors[this.state.editingPageNumber - 1].questionErrors}
          />
        </div>
      </div>
    );
  }
}

PageNavigator.propTypes = {
  editingPageNumber : PropTypes.number.isRequired,
  pages : PropTypes.arrayOf(PropTypes.instanceOf(Page)).isRequired,
  errors : PropTypes.arrayOf(PropTypes.instanceOf(PageErrors)).isRequired,
  handleOnPageSwitch : PropTypes.func.isRequired,
  handleOnPagesUpdate : PropTypes.func.isRequired,
  newEditingQuestionType : PropTypes.string.isRequired,
  editingQuestionNumber : PropTypes.number.isRequired,
  handleOnQuestionsArraySave : PropTypes.func.isRequired,
  handleOnEditingQuestionNumberChange : PropTypes.func.isRequired,
};
