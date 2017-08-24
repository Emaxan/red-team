import React, { Component } from 'react';
import { Form, Col, Panel, FormGroup, FormControl, ControlLabel, Button } from 'react-bootstrap';
import PropTypes from 'prop-types';

import { questionTypesArray } from './questionTypesPresentation';
import { QuestionTypesPanel } from './QuestionTypesPanel';
import { QuestionList } from './QuestionList';

import './SurveyEditPanel.scss';

export class SurveyEditPanel extends Component {
  constructor(props) {
    super(props);

    this.state = {
      editingPageNumber : 1,
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
  }

  handleOnTitleChange = (event) => {
    this.setState({ survey : { ...this.state.survey, title : event.target.value }});
  }

  handleOnQuestionsArraySave = (questions) => {
    let { pages } = this.state.survey;
    pages[this.state.editingPageNumber - 1].questions = questions;
    this.setState({survey : { ...this.state.survey, pages }});
  }

  render = () => {
    return (
      <div className="survey-edit-panel">
        <Panel className="col-md-6">
          <Form horizontal>
            <FormGroup controlId="title" >
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

            <QuestionList
              questions={this.state.survey.pages[this.state.editingPageNumber - 1].questions}
            />

            <FormGroup className="text-center">
              <Button onClick={this.handleOnSave} type="submit">
                Save
              </Button>
            </FormGroup>
          </Form>
        </Panel>

        <QuestionTypesPanel
          handleOnTypeChange={this.handleOnTypeChange}
          questionTypesArray={questionTypesArray}
        />
      </div>
    );
  }
}

SurveyEditPanel.propTypes = {
  survey: PropTypes.object.isRequired,
  saveSurvey : PropTypes.func.isRequired,
};
