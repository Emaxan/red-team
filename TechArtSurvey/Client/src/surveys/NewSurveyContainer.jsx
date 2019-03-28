import React from 'react';
import { connect } from 'react-redux';

import { SurveyEditPanel } from './components/SurveyEditPanel';
import Survey from './models/Survey';
import { createSurveyRequest, cancelSurveyCreationRequest } from './actions';

const mapStateToProps = (state) => ({
  errors : state.surveys.errors,
  survey : new Survey(),
});

const mapDispatchToProps = {
  saveSurvey : createSurveyRequest,
  cancelSurveyCreation : cancelSurveyCreationRequest,
};

const NewSurveyContainer = ({ errors, survey, saveSurvey, cancelSurveyCreation }) => (
  <SurveyEditPanel
    errors={errors}
    survey={survey}
    saveSurvey={saveSurvey}
    cancelSurveyCreation={cancelSurveyCreation}
  />
);

NewSurveyContainer.propTypes = {
  ...SurveyEditPanel.propTypes,
};

export default connect(mapStateToProps, mapDispatchToProps)(NewSurveyContainer);
