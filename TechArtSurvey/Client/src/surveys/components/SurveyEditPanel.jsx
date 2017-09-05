import React, { Component } from 'react';
import { Form, Col, Panel, FormGroup, FormControl, ControlLabel, Button, ButtonGroup, ButtonToolbar } from 'react-bootstrap';
import PropTypes from 'prop-types';

import { questionTypesArray } from './questionTypesPresentation';
import { QuestionTypesPanel } from './QuestionTypesPanel';
import { ParamsPanel } from './ParamsPanel';
import Survey from '../models/Survey';
import SurveyErrors from '../models/SurveyErrors';
import { PageNavigator } from './PageNavigator';
import { isSurveyValid, prepareSurvey } from './service';
import { validateTitle } from '../../utils/validation/commonValidation';

import './SurveyEditPanel.scss';

export class SurveyEditPanel extends Component {
  constructor(props) {
    super(props);

    const survey = this.props.survey.getCopy();

    this.state = {
      editingPageNumber : 1,
      editingQuestionNumber : -1,
      newEditingQuestionType: null,
      survey,
    };

    this.errors = new SurveyErrors();

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
    let survey = this.state.survey.getCopy();
    survey.title = title;
    this.setState({survey});
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

  handleOnPagesUpdate = (pages, errors) => {
    let newPages = pages.map(p => p.getCopy());
    let survey = this.state.survey.getCopy();
    survey.pages = newPages;
    this.setState({survey});
    this.errors.pageErrors = errors;
  }

  handleOnSettingsChange = (settings) => {
    const newSettings = settings.getCopy();
    let survey = this.state.survey.getCopy();
    survey.settings = newSettings;
    this.setState({survey});
  }

  handleOnCancelClick = () => {
    this.props.cancelSurveyCreation();
  }

  handleOnPageSwitch = (pageNumber) => {
    this.setState({
      editingPageNumber : pageNumber,
      editingQuestionNumber : -1,
      newEditingQuestionType : null,
    });
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
                <Button onClick={this.handleOnCancelClick}>
                  Cancel
                </Button>
              </ButtonGroup>
            </ButtonToolbar>
            <PageNavigator
              handleOnPagesUpdate={this.handleOnPagesUpdate}
              pages={this.state.survey.pages}
              editingQuestionNumber={this.state.editingQuestionNumber}
              newEditingQuestionType={this.state.newEditingQuestionType}
              handleOnEditingQuestionNumberChange={this.handleOnEditingQuestionNumberChange}
              handleOnPageSwitch={this.handleOnPageSwitch}
              errors={this.errors.pageErrors}
            />
          </Form>
        </Panel>
        <div className='settings-panel'>
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
  survey : PropTypes.instanceOf(Survey).isRequired,
  saveSurvey : PropTypes.func.isRequired,
  cancelSurveyCreation : PropTypes.func.isRequired,
};
