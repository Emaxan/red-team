import React, { Component } from 'react';
import { Col, FormGroup, FormControl, Glyphicon, NavItem, Nav, ControlLabel } from 'react-bootstrap';
import PropTypes from 'prop-types';

import { isPageValid } from './service';
import QuestionList from './QuestionList';
import Page from '../models/Page';
import PageErrors from '../models/PageErrors';
import { validateTitle } from '../../utils/validation/commonValidation';
import { reactBootstrapValidationUtility as rbValidationUtility } from '../../utils/validation/reactBootstrapValidationUtility';

import './PageNavigator.scss';

export class PageNavigator extends Component {
  constructor(props) {
    super(props);

    this.state = {
      editingPageNumber : 1,
      pages : this.props.pages.map(p => p.getCopy()),
    };

    this.errors = this.props.errors.map(e => e.getCopy());

    this.validationStates = {
      title : null,
    };
  }

  componentWillReceiveProps = (props) => {
    let pages = props.pages.map(p => p.getCopy());
    this.setState({ pages });
    this.errors = props.errors.map(e => e.getCopy());
  }

  handleOnAddPageClick = () => {
    let pages = this.state.pages.map(p => p.getCopy());
    pages.push(new Page(pages.length + 1));

    this.setState({
      editingPageNumber : pages.length,
      pages,
    });

    this.errors.push(new PageErrors());
    this.props.handleOnPagesUpdate(pages, this.errors);
    this.props.handleOnPageSwitch(pages.length);
    this.props.handleOnEditingQuestionNumberChange(0);
  }

  handleOnPageSwitch = (pageNumber) => {
    if (pageNumber !== this.state.editingPageNumber) {
      this.setState({ editingPageNumber : pageNumber });
      this.props.handleOnPageSwitch(pageNumber);
    }
  }

  handleOnDeletePageClick = () => {
    let pages = this.state.pages.map(p => p.getCopy());

    if (pages.length !== 1) {
      pages.splice(this.state.editingPageNumber - 1, 1);
      this.errors.splice(this.state.editingPageNumber - 1, 1);

      this.setState({
        editingPageNumber : 1,
        pages,
      });

      this.props.handleOnPagesUpdate(pages, this.errors);
      this.handleOnPageSwitch(1);
    }
  }

  handleOnPageTitleChange = (event) => {
    let title = event.target.value;
    rbValidationUtility.setValidationState('title', this.errors[this.state.editingPageNumber - 1], this.validationStates, validateTitle(title));

    let pages = this.state.pages.map(p => p.getCopy());
    pages[this.state.editingPageNumber - 1].title = title;
    this.setState({ pages });

    this.props.handleOnPagesUpdate(pages, this.errors);
  }

  handleOnQuestionsArraySave = (questions, errors, resetEditingQuestionNumber = true) => {
    this.errors[this.state.editingPageNumber - 1].questionErrors = errors;

    let pages = this.state.pages.map(p => p.getCopy());
    pages[this.state.editingPageNumber - 1].questions = questions.map(q => q.getCopy());

    this.props.handleOnPagesUpdate(pages, this.errors);

    if (resetEditingQuestionNumber) {
      this.props.handleOnEditingQuestionNumberChange(-1);
    }
  }

  render = () => {
    return (
      <div>
        <Nav bsStyle="tabs" activeKey={this.state.editingPageNumber} justified>
          {
            this.state.pages.map((page, index) => (
              <NavItem key={index} eventKey={index + 1} onSelect={this.handleOnPageSwitch}>
                <div className={isPageValid(this.errors[index]) ? '' : 'error-tab'}>
                  {
                    (page.title && page.title.trim().length > 0)
                      ? <span>{page.title}</span>
                      : <span>Page {index + 1}</span>
                  }
                </div>
              </NavItem>
            ))
          }
          <NavItem onSelect={this.handleOnAddPageClick}>
            <Glyphicon glyph="plus" className="text-muted" />
          </NavItem>
        </Nav>
        <div className="page">
          <div className="page-control">
            <FormGroup className="page-form-group" validationState={this.validationStates.title}>
              <Col sm={10}>
                <ControlLabel>
                  {this.errors[this.state.editingPageNumber - 1].title || 'Page title'}
                </ControlLabel>
                <FormControl
                  type="text"
                  value={this.state.pages[this.state.editingPageNumber - 1].title}
                  onChange={this.handleOnPageTitleChange}
                  placeholder="Enter page title"
                />
              </Col>
            </FormGroup>
            <Glyphicon glyph="trash" role="button" title="Remove page" onClick={this.handleOnDeletePageClick} className="page-delete"/>
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
  pages : PropTypes.arrayOf(PropTypes.instanceOf(Page)).isRequired,
  errors : PropTypes.arrayOf(PropTypes.instanceOf(PageErrors)).isRequired,
  handleOnPagesUpdate : PropTypes.func.isRequired,
  handleOnPageSwitch : PropTypes.func.isRequired,
  newEditingQuestionType : PropTypes.string.isRequired,
  editingQuestionNumber : PropTypes.number.isRequired,
  handleOnEditingQuestionNumberChange : PropTypes.func.isRequired,
};
