import React, { Component } from 'react';
import { Form, Col, Panel, FormGroup, FormControl, ControlLabel, Button, ButtonGroup } from 'react-bootstrap';
import PropTypes from 'prop-types';

import { questionTypesArray } from './questionTypesPresentation';
import { QuestionTypesPanel } from './QuestionTypesPanel';
import { ParamsPanel } from './ParamsPanel';
import Page from '../models/Page';
import { PageNavigator } from './PageNavigator';
import { isSurveyValid, prepareSurvey } from './service';
import {
  TITLE_IS_REQUIRED,
} from './errors';

import './SurveyEditPanel.scss';

export class SurveyEditPanel extends Component {
  constructor(props) {
    super(props);

    this.state = {
      editingPageNumber : 1,
      editingQuestionNumber : -1,
      newEditingQuestionType: null,
      survey : {
        title : this.props.survey.title,
        pages : this.props.survey.pages,
        settings : {
          isAnonymous : this.props.survey.settings.isAnonymous,
          hasQuestionNumbers : this.props.survey.settings.hasQuestionNumbers,
          hasPageNumbers : this.props.survey.settings.hasPageNumbers,
          isRandomOrdered : this.props.survey.settings.isRandomOrdered,
          hasRequiredFieldsStars : this.props.survey.settings.hasRequiredFieldsStars,
          hasProgressIndicator : this.props.survey.settings.hasProgressIndicator,
        },
      },
    };

    this.errors = {
      survey : {
        title : '',
        pages : [{
          title : '',
          questions : [],
        }],
      },
    };
  }

  handleOnTitleChange = (event) => {
    this.setState({ survey : { ...this.state.survey, title : event.target.value }});
    if(event.target.value.trim().length === 0) {
      this.errors.survey.title = TITLE_IS_REQUIRED;
    } else {
      this.errors.survey.title = null;
    }
  }

  handleOnSaveClick = () => {
    if(!isSurveyValid(this.errors.survey)) {
      alert('Invalid survey. Check up all required fields.');
      return;
    }
    let survey = prepareSurvey(this.state.survey);
    console.log(survey);
    alert('Zaebis! Chotko! Survey is ready to be sent to the server');
  }

  handleOnQuestionsArraySave = (questions, errors) => {
    let pages = this.state.survey.pages.map(q => ({...q}));
    pages[this.state.editingPageNumber - 1].questions = questions;
    this.setState({
      survey : { ...this.state.survey, pages : pages },
      newEditingQuestionType : null,
    });
    this.errors.survey.pages = errors.pages;
  }

  handleOnTypeChange = (type) => {
    if (this.state.editingQuestionNumber === -1) {
      return;
    }
    this.setState({ newEditingQuestionType : type });
  }

  handleOnEditingQuestionNumberChange = (number) => {
    this.setState({
      editingQuestionNumber : number,
      newEditingQuestionType : null,
    });
  }

  handleOnPageSwitch = (pageNumber) => {
    this.setState({
      editingPageNumber : pageNumber,
      editingQuestionNumber : -1,
      newEditingQuestionType : null,
    });
  }

  handleOnAddPageClick = () => {
    let pages = this.state.survey.pages.map(q => ({...q}));
    pages.push(new Page());
    this.setState({
      editingPageNumber : pages.length,
      editingQuestionNumber : -1,
      newEditingQuestionType : null,
      survey : { ...this.state.survey, pages : pages },
    });
    this.errors.survey.pages.push({
      title : '',
      questions : [],
    });
  }

  handleOnPagesUpdate = (pages, errors) => {
    let newPages = pages.map(p => ({...p}));
    this.setState({ survey : { ...this.state.survey, pages : newPages } });
    this.errors.survey.pages = errors.pages;
  }

  handleOnSettingsChange = (settings) => {
    let newSettings = {...settings};
    this.setState({ survey : { ...this.state.survey, settings : newSettings } });
  }

  getEditingQuestionType() {
    if(this.state.editingQuestionNumber === -1) {
      return null;
    }
    if(this.state.newEditingQuestionType) {
      return this.state.newEditingQuestionType;
    }
    let questions = this.state.survey.pages[this.state.editingPageNumber - 1].questions;
    let index = questions.findIndex(q => q.number == this.state.editingQuestionNumber);
    return questions[index].type;
  }

  render = () => {
    return (
      <div className="survey-edit-panel">
        <Panel className="col-md-6">
          <Form horizontal>
            <FormGroup controlNumber="title" >
              <Col componentClass={ControlLabel} sm={2}>
                New survey
              </Col>
              <Col sm={10}>
                <FormControl
                  type="text"
                  value={this.state.survey.title}
                  placeholder="Enter title"
                  onChange={this.handleOnTitleChange}
                />
              </Col>
            </FormGroup>
            <ButtonGroup>
              <Button onClick={this.handleOnSaveClick}>
                Save
              </Button>
              <Button >
                Save as template
              </Button>
              <Button>
                Cancel
              </Button>
              <Button onClick={this.handleOnAddPageClick}>
                New page
              </Button>
            </ButtonGroup>
            <PageNavigator
              handleOnPagesUpdate={this.handleOnPagesUpdate}
              handleOnPageSwitch={this.handleOnPageSwitch}
              pages={this.state.survey.pages}
              editingPageNumber={this.state.editingPageNumber}
              handleOnQuestionsArraySave={this.handleOnQuestionsArraySave}
              editingQuestionNumber={this.state.editingQuestionNumber}
              newEditingQuestionType={this.state.newEditingQuestionType}
              handleOnEditingQuestionNumberChange={this.handleOnEditingQuestionNumberChange}
              errors={this.errors.survey.pages}
            />
          </Form>
        </Panel>
        <div>
          <div>
            <QuestionTypesPanel
              handleOnTypeChange={this.handleOnTypeChange}
              questionTypesArray={questionTypesArray}
              editingQuestionType={this.getEditingQuestionType()}
            />
            <ParamsPanel
              handleOnSettingsChange={this.handleOnSettingsChange}
              settings={this.state.survey.settings}
            />
          </div>
        </div>
      </div>
    );
  }
}

SurveyEditPanel.propTypes = {
  survey : PropTypes.object.isRequired,
  saveSurvey : PropTypes.func.isRequired,
};