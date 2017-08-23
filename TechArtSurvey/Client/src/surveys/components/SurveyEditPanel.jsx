import React, { Component } from 'react';
import { Form, Col, Panel, FormGroup, FormControl, ControlLabel } from 'react-bootstrap';
import PropTypes from 'prop-types';

import { questionTypesArray } from './questionTypesPresentation';
import { QuestionTypesPanel } from './QuestionTypesPanel';
import { QuestionList } from './QuestionList';
import Question from './Question';

import './SurveyEditPanel.scss';

export class SurveyEditPanel extends Component {
  constructor(props) {
    super(props);

    this.state = {
      editingQuestion: -1,
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
    newQuestionsArray.push(new Question(newQuestionsArray.length, this.props.defaultType));
    this.setState({editingQuestion: newQuestionsArray.length - 1});
    this.setState({ survey : { ...this.state.survey, questions : newQuestionsArray }});
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
    this.props.editingQuestion = id;
  }

  handleOnTypeChange = (type) => {
    var questionId = this.state.editingQuestion;
    var questions = this.state.survey.questions;
    if(questionId > -1 && questionId < questions.length){
      var oldQuestion = questions[questionId];
      if(oldQuestion.type != type){
        var newQuestion = new Question(questionId, type, oldQuestion.text, oldQuestion.isRequired);
        if((oldQuestion.type == this.props.questionTypes.SINGLE_ANSWER
          || oldQuestion.type == this.props.questionTypes.MULTIPLE_ANSWER)
          && (type == this.props.questionTypes.SINGLE_ANSWER
          || type == this.props.questionTypes.MULTIPLE_ANSWER))
        {
          newQuestion.metaInfo = oldQuestion.metaInfo;
        }
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
  editingQuestion: PropTypes.number.isRequired,
};
