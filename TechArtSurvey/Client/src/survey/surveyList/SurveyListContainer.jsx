import React from 'react';
import { connect } from 'react-redux';

import { getSurveys, setFilter, cleanSurveys } from './actions';
import { SurveyList } from './components/SurveyList';
import FilteredSurveys from './selectors/filteredSurveys';

const mapStateToProps = (state) => ({
  surveyList : state.surveyList.surveyList,
  filteredSurveyList : FilteredSurveys(state),
  isFetching : state.surveyList.isFetching,
  email : state.auth.userInfo.email,
});

const mapDispatchToProps = {
  getSurveys,
  setFilter,
  cleanSurveys,
};

const SurveyListContainer = ({ filteredSurveyList, getSurveys, setFilter, isFetching, email, cleanSurveys }) => (
  <div className="survey-list">
    <SurveyList
      filteredSurveyList={filteredSurveyList}
      getSurveys={getSurveys}
      setFilter={setFilter}
      isFetching={isFetching}
      email={email}
      cleanSurveys={cleanSurveys}
    />
  </div>
);

SurveyListContainer.propTypes = {
  ...SurveyList.propTypes,
};

export default connect(mapStateToProps, mapDispatchToProps)(SurveyListContainer);
