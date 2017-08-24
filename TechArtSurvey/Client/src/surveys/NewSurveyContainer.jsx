import React from 'react';
import { connect } from 'react-redux';

import { SurveyEditPanel } from './components/SurveyEditPanel';
import Survey from './models/Survey';

const mapStateToProps = (state) => ({
  errors : state.surveys.errors,
  survey : new Survey(),
});

const NewSurveyContainer = ({ errors, survey }) => (
  <SurveyEditPanel
    errors={errors}
    survey={survey}
  />
);

NewSurveyContainer.propTypes = {
  ...SurveyEditPanel.propTypes,
};

export default connect(mapStateToProps)(NewSurveyContainer);
