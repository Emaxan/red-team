import React, { Component } from 'react';
import { Form, Col, Panel, FormGroup, FormControl, ControlLabel, Button, ButtonGroup, ButtonToolbar, Modal } from 'react-bootstrap';
import PropTypes from 'prop-types';

import { questionTypes } from '../questionTypes';
import { questionTypesArray } from './questionTypesPresentation';
import { QuestionTypesPanel } from './QuestionTypesPanel';
import { PageNavigator } from './PageNavigator';
import { ParamsPanel } from './ParamsPanel';
import Survey from '../models/Survey';
import SurveyErrors from '../models/SurveyErrors';
import { isSurveyValid, prepareSurvey } from './service';
import { validateTitle } from '../../utils/validation/commonValidation';
import { reactBootstrapValidationUtility as rbValidationUtility } from '../../utils/validation/reactBootstrapValidationUtility';

import './SurveyEditPanel.scss';

export class SurveyEditPanel extends Component {
  constructor(props) {
    super(props);

    this.state = {
      editingCanceled : false,
      editingPageNumber : 1,
      editingQuestionNumber : 0,
      newEditingQuestionType: questionTypes.NONE,
      survey : this.props.survey.getCopy(),
    };

    this.errors = new SurveyErrors();

    this.validationStates = {
      title : null,
    };
  }

  handleOnTitleChange = (event) => {
    const title = event.target.value;
    rbValidationUtility.setValidationState('title', this.errors, this.validationStates, validateTitle(title));
    let survey = this.state.survey.getCopy();
    survey.title = title;
    this.setState({ survey });
  }

  handleOnSaveClick = () => {
    if (!isSurveyValid(this.errors)) {
      alert('Invalid survey. Check up all required fields.');
    } else {
      let survey = prepareSurvey(this.state.survey);
      console.log(survey);
      alert('Zaebis! Chotko! Survey is ready to be sent to the server');
    }
  }

  handleOnTypeChange = (type) => {
    if (this.state.editingQuestionNumber !== -1) {
      this.setState({ newEditingQuestionType : type });
    }
  }

  handleOnEditingQuestionNumberChange = (number) => {
    this.setState({
      editingQuestionNumber : number,
      newEditingQuestionType : questionTypes.NONE,
    });
  }

  handleOnPagesUpdate = (pages, errors) => {
    let newPages = pages.map(p => p.getCopy());
    let survey = this.state.survey.getCopy();
    survey.pages = newPages;
    this.setState({ survey });
    this.errors.pageErrors = errors;
  }

  handleOnSettingsChange = (settings) => {
    const newSettings = settings.getCopy();
    let survey = this.state.survey.getCopy();
    survey.settings = newSettings;
    this.setState({ survey });
  }

  handleOnCancelClick = () => {
    this.setState({ editingCanceled : true });
  }

  handleOnConfirmCancellationClick = () => {
    this.props.cancelSurveyCreation();
  }

  handleOnUndoCancellationClick = () => {
    this.setState({ editingCanceled : false });
  }

  handleOnPageSwitch = (pageNumber) => {
    this.setState({
      editingPageNumber : pageNumber,
      editingQuestionNumber : -1,
      newEditingQuestionType : questionTypes.NONE,
    });
  }

  getEditingQuestionType() {
    if (this.state.editingQuestionNumber === -1) {
      return questionTypes.NONE;
    }

    let { questions } = this.state.survey.pages[this.state.editingPageNumber - 1];
    let index = questions.findIndex(q => q.number === this.state.editingQuestionNumber);

    return questions[index].type;
  }

  render = () => {
    return (
      <div className="survey-edit-panel">
        <Panel className="col-md-6 col-md-offset-3">
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
                  placeholder="Enter survey title"
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

        <Modal
          show={this.state.editingCanceled}
          onHide={this.handleOnUndoCancellationClick}
          container={this}
        >
          <Modal.Header>
            Are you sure that you want to cancel your actions?
          </Modal.Header>
          <Modal.Footer>
            <Button onClick={this.handleOnConfirmCancellationClick}>Yes</Button>
            <Button onClick={this.handleOnUndoCancellationClick}>No</Button>
          </Modal.Footer>
        </Modal>
      </div>
    );
  }
}

SurveyEditPanel.propTypes = {
  survey : PropTypes.instanceOf(Survey).isRequired,
  saveSurvey : PropTypes.func.isRequired,
  cancelSurveyCreation : PropTypes.func.isRequired,
};
