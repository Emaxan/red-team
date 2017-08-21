import React, { Component } from 'react';
import { Form, Panel, FormGroup, FormControl, ControlLabel } from 'react-bootstrap';
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
        <Panel className="col-md-8">
          <Form>
            <FormGroup
              controlId="Title"
            >
              <ControlLabel>New survey</ControlLabel>
              <FormControl
                type="text"
                value={this.state.survey.title}
                placeholder="Enter title"
                onChange={this.handleOnTitleChange}
              />
              <FormControl.Feedback />
            </FormGroup>
          </Form>
        </Panel>
        <Panel header="Kek" bsStyle="primary">
          <ul>
            <li>kek</li>
            <li>kek</li>
            <li>kek</li>
            <li>kek</li>
            <li>kek</li>
          </ul>
        </Panel >
      </div>
    );
  }
}

SurveyEditPanel.propTypes = {
  createSurvey : PropTypes.func.isRequired,
  addPage : PropTypes.func.isRequired,
  defaultType : PropTypes.string.isRequired,
};