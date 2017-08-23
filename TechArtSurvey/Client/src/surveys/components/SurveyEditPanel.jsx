import React, { Component } from 'react';
import { Form, Col, Panel, FormGroup, FormControl, ControlLabel } from 'react-bootstrap';
import PropTypes from 'prop-types';

import { questionTypesArray } from './questionTypesPresentation';
import { QuestionTypesPanel } from './QuestionTypesPanel';
import { QuestionList } from './QuestionList';
import Question from './Question';
import { changeType } from './service';

import './SurveyEditPanel.scss';

export class SurveyEditPanel extends Component {
  constructor(props) {
    super(props);

    this.lastId = -1;

    this.state = {
      editingQuestionId: this.lastId,
      survey : {
        title : '',
        questions : [],
        pages : [],
        params : {
          isAnonymous : false,
          hasQuestionNumbers : true,
          hasPageNumbers : true,
          isRandomOrdered : false,
          hasRequiredFieldsStars : false,
          hasProgressIndicator : false,
        },
      },
    };
  }

  handleOnAddQuestionBtnClick = () => {
    var newQuestionsArray = this.state.survey.questions;
    newQuestionsArray.push(new Question(++this.lastId, newQuestionsArray.length + 1));
    this.setState({editingQuestionId: this.lastId,  survey : { ...this.state.survey, questions : newQuestionsArray }});
    console.log(this.state.survey.questions);
  }

  handleOnTitleChange = (event) => {
    this.setState({ survey : { ...this.state.survey, title : event.target.value }});
  }

  handleOnQuestionChange = (question) => {
    var questions = this.state.survey.questions;
    questions[question.id] = question;
    this.setState({ survey : { ...this.state.survey, questions : questions}});
  }

  handleOnEditingQuestionChange = (id) => {
    this.setState({editingQuestionId: id});
  }

  handleOnTypeChange = (type) => {
    var questions = this.state.survey.questions;
    var questionId = this.state.editingQuestionId;
    if(questionId != -1) {
      var oldQuestion = questions[questionId];
      var newQuestion = changeType(oldQuestion, type);
      if(newQuestion != null) {
        questions[questionId] = newQuestion;
        this.setState({ survey : { ...this.state.survey, questions : questions}});
      }
    }
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
              questions={this.state.survey.questions}
              handleOnAddQuestionBtnClick = {this.handleOnAddQuestionBtnClick}
              handleOnQuestionChange = {this.handleOnQuestionChange}
              handleOnEditingQuestionChange = {this.handleOnEditingQuestionChange}
              editingQuestionId = {this.state.editingQuestionId}
            />
          </Form>
        </Panel>
        <QuestionTypesPanel handleOnTypeChange = {this.handleOnTypeChange} questionTypesArray={questionTypesArray}/>
      </div>
    );
  }
}

SurveyEditPanel.propTypes = {
  createSurvey : PropTypes.func.isRequired,
  addPage : PropTypes.func.isRequired,
  defaultType : PropTypes.string,
  questionTypes : PropTypes.object,
  editingQuestionId: PropTypes.number.isRequired,
};
