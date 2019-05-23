import React from 'react';
import { connect } from 'react-redux';

import { getSurvey } from './actions';
import { Survey } from './Survey';

const mapStateToProps = (state) => ({
  survey: state.passSurvey.survey,
  isFetching: state.passSurvey.isFetching,
});

const mapDispatchToProps = {
  getSurvey,
};

const SurveyContainer = ({ survey, isFetching, getSurvey, match }) => (
  <div id="pass_survey_container">
    <Survey
      match={match}
      survey={survey}
      getSurvey={getSurvey}
      isFetching={isFetching}
    />
  </div>
);

SurveyContainer.propTypes = {
  ...Survey.propTypes,
};

export default connect(mapStateToProps, mapDispatchToProps)(SurveyContainer);
