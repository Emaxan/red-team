import React, { Component } from 'react';
import { Form, FormGroup, FormControl, ControlLabel } from 'react-bootstrap';
import PropTypes from 'prop-types';

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
  }

  handleOnTitleChange = (event) => {
    this.setState({ survey : { ...this.state.survey, title : event.target.value }});
  }

  render() {
    return (
      <div className="survey-edit-panel">
        <Form horizontal>
          <FormGroup className="label-floating" controlId="title">
            <ControlLabel>
                New survey
            </ControlLabel>
            <FormControl
              name="title"
              type="text"
              value={this.state.survey.title}
              onChange={this.handleOnTitleChange}
            />
            <FormControl.Feedback />
          </FormGroup>
        </Form>
      </div>
    );
  }
}

SurveyEditPanel.propTypes = {
  createSurvey : PropTypes.func.isRequired,
  addPage : PropTypes.func.isRequired,
  defaultType : PropTypes.string.isRequired,
};