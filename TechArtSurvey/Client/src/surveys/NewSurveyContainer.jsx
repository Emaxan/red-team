import React from 'react';
import { connect } from 'react-redux';

import { createSurveyRequest } from './actions';
import { SurveyEditPanel } from './components/SurveyEditPanel';

const mapStateToProps = (state) => ({
  errors : state.surveys.errors,
});

const mapDispatchToProps = {
  createSurveyRequest,
};

const NewSurveyContainer = ({ errors, createSurveyRequest }) => (
  <SurveyEditPanel
    createSurvey={createSurveyRequest}
    errors={errors}
  />
);

NewSurveyContainer.propTypes = {
  ...SurveyEditPanel.propTypes,
};

export default connect(mapStateToProps, mapDispatchToProps)(NewSurveyContainer);
