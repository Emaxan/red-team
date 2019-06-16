import React, { Component } from 'react';
import PropTypes from 'prop-types';
import ReactRouterPropTypes from 'react-router-prop-types';
// import { Dropdown } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import * as SurveyJS from 'survey-react';
import * as SurveyJSEditor from 'surveyjs-editor';
import { Spinner } from '../../components/Spinner';
import { prepareResponseToSend } from './passUtils';

import AuthService from '../../auth/authService';
import { EditorUtils } from '../surveyEditor/editorUtils';

import 'survey-react/survey.css';
import './Survey.scss';

import 'surveyjs-editor/surveyeditor.css';

import 'jquery-ui/themes/base/all.css';
import 'select2/dist/css/select2.css';

import 'jquery-bar-rating/dist/themes/css-stars.css';
import 'jquery-bar-rating/dist/themes/fontawesome-stars.css';

import $ from 'jquery';
import 'jquery-ui/ui/widgets/datepicker.js';
import 'select2/dist/js/select2.js';
import 'jquery-bar-rating';

import 'icheck/skins/square/blue.css';

window['$'] = window['jQuery'] = $;
require('icheck');
// eslint-disable-next-line no-unused-vars
import * as widgets from 'surveyjs-widgets';

widgets.jquerybarrating(SurveyJS, $);
widgets.jqueryuidatepicker(SurveyJS, $);

export class Survey extends Component {
  constructor(props) {
    super(props);
    this.state = {json: null};
  }

  componentDidMount() {
    var mainColor = '#32292a';
    var mainHoverColor = '#ff0000';
    var textColor = '#4a4a4a';
    var headerColor = '#4a4a4a';
    var headerBackgroundColor = '#f8f8f8';
    var bodyContainerBackgroundColor = '#f8f8f8';
    var defaultThemeColorsSurvey = SurveyJS
      .StylesManager
      .ThemeColors['default'];
    defaultThemeColorsSurvey['$main-color'] = mainColor;
    defaultThemeColorsSurvey['$main-hover-color'] = mainHoverColor;
    defaultThemeColorsSurvey['$text-color'] = textColor;
    defaultThemeColorsSurvey['$header-color'] = headerColor;
    defaultThemeColorsSurvey['$header-background-color'] = headerBackgroundColor;
    defaultThemeColorsSurvey['$body-container-background-color'] = bodyContainerBackgroundColor;
    SurveyJS.StylesManager.applyTheme();
    this.props.getSurvey(this.props.match.params.surveyId, this.props.match.params.version).then(() => {
      const stdSurvey = '{"pages": [{"name": "page1"}]}';
      const survey = !this.props.survey.author ?
        stdSurvey :
        JSON.stringify(EditorUtils.prepareAfterLoad(this.props.survey, true));

      let editor = new SurveyJSEditor.SurveyEditor(
        'surveyEditorContainer',
        {},
      );

      editor.text = survey;
      const RSM = new SurveyJS.ReactSurveyModel(editor.getSurveyJSON());
      RSM.locale = this.props.match.params.lang;
      RSM.onComplete.add((result) => this.props.sendResponse(prepareResponseToSend({
        survey: editor.survey,
        data: result.data,
        surveyId: this.props.match.params.surveyId,
        surveyVersion: this.props.match.params.version,
        userName: AuthService.getUserInfo().userName,
        email: AuthService.getUserInfo().email,
      })));

      this.setState({...this.state, json: editor.getSurveyJSON(), RSM});

    });
  }

  render = () => {

    let langPanel = '';
    if (this.state.json !== null) {
      const {json} = this.state;
      const langs = [];
      if(json.title && json.title.default) Object.keys(json.title).forEach(key => langs.push(key));
      langPanel =  (
        <div>
          {
            langs.length > 0 ?
              <div className="select-language alert alert-secondary">
                Select Language:
                {
                  langs.map((lang, i) => (<Link key={i} className="dropdown-item" to={'./' + lang}>{lang}</Link>))
                }
              </div> : ''
          }
          <div id="pass_survey">
            <SurveyJS.Survey
              model={this.state.RSM}
            />
          </div>
        </div>
      );
    }
    return (
      <div>
        {
          this.props.isFetching && <div className="spinner-absolute"><Spinner /></div>
        }
        {
          langPanel
        }
      </div>
    );
  }
}

Survey.propTypes = {
  isFetching: PropTypes.bool.isRequired,
  survey: PropTypes.object.isRequired,
  getSurvey: PropTypes.func.isRequired,
  sendResponse: PropTypes.func.isRequired,
  match: ReactRouterPropTypes.match.isRequired,
};
