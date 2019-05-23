import React, { Component } from 'react';
import PropTypes from 'prop-types';

import { SearchBox } from './SearchBox';
import { Spinner } from '../../../components/Spinner';
import { Survey } from './Survey';

import './SurveyList.scss';

export class SurveyList extends Component {
  constructor(props) {
    super(props);

    this.state = {
      onlyMy: false,
    };
    this.setOnlyMyRef = element => {
      this.onlyMy = element;
    };
  }

  handleOnBtnClick = () => {
    this.props.cleanSurveys();
    this.props.getSurveys(this.onlyMy.checked ? this.props.email : '');
  }

  componentDidMount() {
    this.handleOnBtnClick();
  }

  render = () => {
    let spinner = this.props.isFetching ? (
      <div className="spinner-absolute">
        <Spinner />
      </div>
    ) : '';

    let surveys = '';

    if (this.props.filteredSurveyList.length > 0) {
      surveys = this.props.filteredSurveyList.map((survey) => {
        const title = survey.versions[survey.versions.length - 1].title.default;
        const author = survey.author.userName;
        const { startDate, endDate, locale, number } = survey.versions[survey.versions.length - 1];
        return (
          <Survey key={survey.id} id={survey.id} version={number} title={title} author={author}
            startDate={startDate} endDate={endDate} locale={locale}
          />);
      });
    } else {
      surveys = (<h2>There is no surveys matched your filter</h2>);
    }

    return (
      <div>
        {
          spinner
        }
        <div className={this.props.isFetching ? 'blur' : ''}>
          <h2>Surveys</h2>
          <SearchBox setFilter={this.props.setFilter} />
          <label className="only-my-survey">
            <input className="only-my-survey__input" type="checkbox" name="onlyMy" ref={this.setOnlyMyRef}/>
            Show only my surveys
          </label>
          <button onClick={this.handleOnBtnClick}>Search</button>
          <div className="surveys_container">
            {
              surveys
            }
          </div>
        </div>
      </div>
    );
  }
}

SurveyList.propTypes = {
  filteredSurveyList : PropTypes.array.isRequired,
  getSurveys : PropTypes.func.isRequired,
  setFilter : PropTypes.func.isRequired,
  cleanSurveys : PropTypes.func.isRequired,
  isFetching : PropTypes.bool.isRequired,
  onlyMy : PropTypes.bool,
  email : PropTypes.string.isRequired,
};
