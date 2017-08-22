import React, { Component } from 'react';
import { Form, Col, Panel, FormGroup, FormControl, ControlLabel } from 'react-bootstrap';
import PropTypes from 'prop-types';

import { questionTypesArray } from './questionTypesPresentation';
import { QuestionTypesPanel } from './QuestionTypesPanel';
import { QuestionList } from './QuestionList';

export class SurveyEditPanel extends Component {
  constructor(props) {
    super(props);

    this.state = {
      survey : {
        title : '',
        questions: [],
        pages: 1,
        params: {
          isAnonymous: false,
          hasQuestionNumbers: true,
          hasPageNumbers: true,
          isRandomOrdered: false,
          hasRequiredFieldsStars: false,
          hasProgressIndicator: false,
        },
      },
    };
  }

  handleOnCreateSurveyBtnClick = () => {
    this.props.createSurvey();
  }

  handleOnAddPageBtnClick = () => {
    this.props.addPage();
  }

  handleOnAddQuestionBtnClick = () => {
    var newQuestionsArray = this.state.survey.questions;
    newQuestionsArray.push({
      id: this.state.survey.questions.length,
      type: this.props.defaultType,
      text: '',
      isRequired: false,
    });
    this.setState({ survey : { ...this.state.survey, questions : newQuestionsArray }});
    console.log(this.state.survey);
  }

  handleOnTitleChange = (event) => {
    this.setState({ survey : { ...this.state.survey, title : event.target.value }});
  }

  handleOnQuestionTypeClick = (event) => {
    alert(event.target);
  }

  render() { console.log(this.state.survey.questions);
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
            <QuestionList questions={this.state.survey.questions} handleOnAddQuestionBtnClick = {this.handleOnAddQuestionBtnClick}/>
          </Form>
        </Panel>
        <QuestionTypesPanel handleOnQuestionTypeClick={this.handleOnQuestionTypeClick} questionTypesArray={questionTypesArray}/>
      </div>
    );
  }
}

SurveyEditPanel.propTypes = {
  createSurvey : PropTypes.func.isRequired,
  addPage : PropTypes.func.isRequired,
  defaultType : PropTypes.string,
  questionTypes : PropTypes.object,
};