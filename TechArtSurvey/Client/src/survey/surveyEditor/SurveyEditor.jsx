import React, { Component } from 'react';
import { connect } from 'react-redux';
import PropTypes from 'prop-types';
import ReactRouterPropTypes from 'react-router-prop-types';
import { pushSurveyRequest, getSurveyRequest } from './actions';
import { EditorUtils } from './editorUtils';
import * as SurveyJSEditor from 'surveyjs-editor';
import * as SurveyKo from 'survey-knockout';
import { validateSurvey, validator } from './validators/surveyValidator';
import $ from 'jquery';

import 'survey-react/survey.css';

import 'surveyjs-editor/surveyeditor.css';
import './SurveyEditor.scss';

import 'jquery-ui/themes/base/all.css';
import 'select2/dist/css/select2.css';

import 'jquery-bar-rating/dist/themes/css-stars.css';
import 'jquery-bar-rating/dist/themes/fontawesome-stars.css';

import 'jquery-ui/ui/widgets/datepicker.js';
import 'select2/dist/js/select2.js';
import 'jquery-bar-rating';

import 'icheck/skins/square/blue.css';

import * as widgets from 'surveyjs-widgets';

widgets.jquerybarrating(SurveyKo, $);
widgets.jqueryuidatepicker(SurveyKo, $);

class SurveyEditor extends Component {
  constructor(props) {
    super(props);

    this.state = {customErrors: [], questionErrors:{pages:[]}};
  }

  editor;

  componentWillMount() {
    const {surveyId, version} = this.props.match.params;
    if (surveyId && version) {
      this.props.getSurveyRequest(surveyId, version);
    } else {
      //error
    }
  }

  componentDidMount() {
    let editorOptions = {
      generateValidJSON: true,	//The default value of this options is true. By default, the valid JSON is generated. You may want to use non-standard, but more readable format, JSON5.
      showJSONEditorTab: true ,	//Set this option to false to hide the JSON Tab. //TODO Remove this later.
      showTestSurveyTab: true,	//Set this option to false to hide the Survey Test Tab.
      showEmbededSurveyTab: false,	//Set this option to true to show the Survey Embedded Tab. This tab is hidden by default. It shows how to integrate the survey into another web page.
      showTranslationTab: true,	//Set this option to true to show the Translation Tab. This tab is hidden by default. It allows to edit all localizable strings for several languages on one page. It allows to import/export into from csv file.
      showPropertyGrid: false,	//Set this option to false to hide the property grid on the right. It is shown by default.
      questionTypes: ['text', 'checkbox', 'radiogroup', 'dropdown', 'boolean', 'comment', 'rating', 'matrix'],	//Use this option to define question types you want to see on the Toolbox. Go to Customize Toolbox section to get more information.
      isAutoSave: false,	//Set this options to true and Builder (Editor) will call the "save callback" function on every change. By default, the "Save" button is shown. For more information, please go to Load and Save Survey section.
      isRTL: true,	//Set this options to true for Right-to-Left web sites.
      showPagesToolbox: true,	//If you are going to allow your users creating only one page surveys, then set this property to false. It will hide the pages toolbox.
      useTabsInElementEditor: false,	//If you want to tabs instead of accordion in the element popup editor, then set this property to true. It will change accordion to tab control.
      showState: false,
    };

    var mainColor = '#32292a';
    var mainHoverColor = '#ff0000';
    var textColor = '#4a4a4a';
    // var headerColor = '#7ff07f';
    // var headerBackgroundColor = '#4a4a4a';
    // var bodyContainerBackgroundColor = '#f8f8f8';
    var defaultThemeColorsEditor = SurveyJSEditor
      .StylesManager
      .ThemeColors['default'];
    defaultThemeColorsEditor['$primary-color'] = mainColor;
    defaultThemeColorsEditor['$secondary-color'] = mainColor;
    defaultThemeColorsEditor['$primary-hover-color'] = mainHoverColor;
    defaultThemeColorsEditor['$primary-text-color'] = textColor;
    defaultThemeColorsEditor['$selection-border-color'] = mainColor;
    SurveyJSEditor.StylesManager.applyTheme();

    // var deutschStrings = {
    //     p: {
    //         isRequired: "Wird bentigt"
    //     }
    // };

    // //Set the your translation to the locale
    // SurveyJSEditor
    //     .localization
    //     .locales["de"] = deutschStrings;
    // //Make this locale the current
    // //SurveyJSEditor.localization.currentLocale = "de";
    this.editor = new SurveyJSEditor.SurveyEditor(
      'surveyEditorContainer',
      editorOptions,
    );
    this.editor.saveSurveyFunc = this.saveMySurvey;
    this.editor.showErrorOnFailedSave = false;

    this.editor.onPropertyValidationCustomError.add((e, opt) => {
      console.log(opt);
      validator(opt);
    });

    this.editor
      .onCanShowProperty
      .add(function (sender, options) {
        if(options.property.name == 'choicesByUrl') options.canShow = false;
        if (options.obj.getType() == 'survey') {
          options.canShow = [
            'title',
            'locale',
            // 'sendResultOnPageNext',
            // 'showPageTitles',
            // 'storeOthersAsComment',
            'showPageNumbers',
            'pagePrevText',
            'pageNextText',
            'completeText',
            'startSurveyText',
            'showNavigationButtons',
            'showPrevButton',
            'firstPageIsStarted',
            'showCompletedPage',
            'completedHtml',
            // 'loadingHtml',
            'maxTimeToFinish',
            'maxTimeToFinishPage',
            'showTimerPanel',
            'showTimerPanelMode',
            'goNextPageAutomatic',
            'showProgressBar',
            'isSinglePage',
            'questionTitleLocation',
            'requiredText',
            'showQuestionNumbers',
            'questionErrorLocation',
            // 'focusFirstQuestionAutomatic',
            'questionsOrder',
            'triggers',
          ].includes(options.property.name);
        }
      });

    $('.svd_commercial_container').remove();
  }

  saveMySurvey = (no, doSaveCallback) => {
    let survey = JSON.parse(this.editor.text);
    const pagesNotExist = !survey.pages || (survey.pages.length === 0);
    if (pagesNotExist) {
      this.setState({
        ...this.state,
        customErrors: ['There are no pages in survey.'],
        survey: survey,
      });
      doSaveCallback(no, false);
      return;
    }
    const isEmptyPages = survey.pages.some((page) => !page.elements || (page.elements.length === 0));
    if (isEmptyPages) {
      this.setState({
        ...this.state,
        customErrors: ['There are pages without questions. Fill or remove it.'],
        survey: survey,
      });
      doSaveCallback(no, false);
      return;
    }
    survey.author = {
      userName: this.props.userName,
      email: this.props.email,
    };
    let s = EditorUtils.prepareSurveyToSend(survey, this.editor.survey);

    const questionErrors = {
      pages:[],
    };
    s.pages.forEach(page => {
      const elements = [];
      for (let i = 0; i < page.elements.length; i++) {
        elements.push({errors:[]});
      }
      questionErrors.pages.push(
        {elements},
      );
    });

    const validation = validateSurvey(s, questionErrors);
    this.setState({
      ...this.state,
      customErrors: validation.customErrors,
      survey: survey,
      questionErrors,
    });
    doSaveCallback(no, validation.isValid);
    if (!validation.isValid) return;
    this.props.pushSurveyRequest(JSON.stringify(s));
  };

  render() {
    if (this.editor) {
      this.editor.text = JSON.stringify(EditorUtils.prepareAfterLoad(this.state.survey || this.props.survey));
      for (let i = 0; i < this.state.questionErrors.pages.length; i++) {
        const errPage = this.state.questionErrors.pages[i];
        const page = this.editor.survey.pages[i];
        for (let j = 0; j < errPage.elements.length; j++) {
          errPage.elements[j].errors.forEach((error) => page.elements[j].errors.push(error));
        }
      }
    }
    return (
      <div>
        {
          this.state.customErrors.map((error, i) => (
            <div key={i} className="alert alert-danger">
              <span className="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
              {error}
            </div>
          ))
        }
        <div id="surveyEditorContainer" />
      </div>
    );
  }
}

const mapStateToProps = (state) => ({
  userName : state.auth.userInfo.userName,
  email : state.auth.userInfo.email,
  survey : state.surveys.survey,
});

const mapDispatchToProps = ({pushSurveyRequest, getSurveyRequest});

SurveyEditor.propTypes = {
  match : ReactRouterPropTypes.match.isRequired,
  userName : PropTypes.string.isRequired,
  email : PropTypes.string.isRequired,
  survey : PropTypes.object.isRequired,
  pushSurveyRequest : PropTypes.func.isRequired,
  getSurveyRequest : PropTypes.func.isRequired,
};

export default connect(mapStateToProps, mapDispatchToProps)(SurveyEditor);
