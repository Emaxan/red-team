import { createSelector } from 'reselect';
import { _ } from 'underscore';

const surveyListSelector = (state) => state.surveyList
  .get('surveyList')
  .toArray();

const filterString = (state) => state.surveyList
  .get('filterInput');

const getFilteredSurveys = (surveyList, input) => {
  const filteredSurveys = _.filter(
    surveyList,
    (survey) => survey.versions[survey.versions.length - 1].title.default
      .toLowerCase()
      .includes(input.toLowerCase()),
  );

  return filteredSurveys;
};

export default createSelector(
  surveyListSelector,
  filterString,
  getFilteredSurveys,
);
