import React from 'react';
import { connect } from 'react-redux';

import {questionTypes, defaultType} from './questionTypes';
import {createSurveyRequest} from './actions';
import {SurveyEditPanel} from './components/SurveyEditPanel';

import './NewSurveyContainer.scss';

const mapStateToProps = (state) => ({
  errors : state.surveys.errors,
});

const mapDispatchToProps = {
  createSurveyRequest,
};

const NewSurveyContainer = ({ errors, createSurveyRequest }) => (
  <SurveyEditPanel
    questionTypes = {questionTypes}
    defaultType = {defaultType}
    createSurvey = {createSurveyRequest}
    errors = {errors}
  />
);

NewSurveyContainer.propTypes = {
  ...SurveyEditPanel.propTypes,
};

export default connect(mapStateToProps, mapDispatchToProps)(NewSurveyContainer);
