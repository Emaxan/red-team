import React, { Component } from 'react';
import { Form, Col, Panel, FormGroup, FormControl, ControlLabel, Button, ButtonGroup, ButtonToolbar } from 'react-bootstrap';
import PropTypes from 'prop-types';

import { questionTypesArray } from './questionTypesPresentation';
import { QuestionTypesPanel } from './QuestionTypesPanel';
import { ParamsPanel } from './ParamsPanel';
import Page from '../models/Page';
import Settings from '../models/Settings';
import { PageNavigator } from './PageNavigator';
import { isSurveyValid, prepareSurvey } from './service';
import { validateTitle } from '../../utils/validation/commonValidation';

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
      title : '',
      pages : [{
        title : '',
        questions : [],
      }],
    };

    this.validationStates = {
      title : null,
    };
  }

  setValidationState = (fieldName, validationInfo) => {
    if (validationInfo.isValid) {
      this.errors[fieldName] = null;
      this.validationStates[fieldName] = 'success';
    } else {
      this.errors[fieldName] = validationInfo.errors[0].message;
      this.validationStates[fieldName] = 'error';
    }
  }

  handleOnTitleChange = (event) => {
    const title = event.target.value;
    this.setValidationState('title', validateTitle(title));
    this.setState({ survey : { ...this.state.survey, title }});
  }

  handleOnSaveClick = () => {
    if(!isSurveyValid(this.errors)) {
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
    this.errors.pages = errors;
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
    this.errors.pages.push({
      title : '',
      questions : [],
    });
  }

  handleOnPagesUpdate = (pages, errors) => {
    let newPages = pages.map(p => ({...p}));
    this.setState({ survey : { ...this.state.survey, pages : newPages } });
    this.errors.pages = errors;
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
    let { questions } = this.state.survey.pages[this.state.editingPageNumber - 1];
    let index = questions.findIndex(q => q.number == this.state.editingQuestionNumber);
    return questions[index].type;
  }

  render = () => {
    return (
      <div className="survey-edit-panel">
        <Panel className="col-md-6">
          <Form horizontal>
            <Col componentClass={ControlLabel} sm={2}>
                New survey
            </Col>
            <FormGroup validationState={this.validationStates.title}>
              <Col sm={10}>
                <ControlLabel>
                  {this.errors.title || 'Title'}
                </ControlLabel>
                <FormControl
                  type="text"
                  value={this.state.survey.title}
                  onChange={this.handleOnTitleChange}
                />
              </Col>
            </FormGroup>
            <ButtonToolbar className="survey-actions">
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
              </ButtonGroup>
              <ButtonGroup className="new-page">
                <Button onClick={this.handleOnAddPageClick}>
                  New page
                </Button>
              </ButtonGroup>
            </ButtonToolbar>
            <PageNavigator
              handleOnPagesUpdate={this.handleOnPagesUpdate}
              handleOnPageSwitch={this.handleOnPageSwitch}
              pages={this.state.survey.pages}
              editingPageNumber={this.state.editingPageNumber}
              handleOnQuestionsArraySave={this.handleOnQuestionsArraySave}
              editingQuestionNumber={this.state.editingQuestionNumber}
              newEditingQuestionType={this.state.newEditingQuestionType}
              handleOnEditingQuestionNumberChange={this.handleOnEditingQuestionNumberChange}
              errors={this.errors.pages}
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
  survey : PropTypes.shape({
    title : PropTypes.string.isRequired,
    settings : PropTypes.instanceOf(Settings).isRequired,
    pages : PropTypes.arrayOf(Page).isRequired,
  }).isRequired,
  saveSurvey : PropTypes.func.isRequired,
};
