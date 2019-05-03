import React, { Component } from 'react';
import { connect } from 'react-redux';
import PropTypes from 'prop-types';
import ReactRouterPropTypes from 'react-router-prop-types';
import { pushSurveyRequest, getSurveyRequest } from './actions';
import * as SurveyJSEditor from 'surveyjs-editor';
import * as SurveyKo from 'survey-knockout';
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

    this.editor
      .onCanShowProperty
      .add(function (sender, options) {
        // console.log(options.obj.getType(), options.property.name);
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

  render() {
    if(this.editor) this.editor.text = JSON.stringify(this.prepareAfterLoad(this.props.survey));
    return <div id="surveyEditorContainer" />;
  }

  saveMySurvey = () => {
    let s = this.prepareSurveyToSend(JSON.parse(this.editor.text));
    this.props.pushSurveyRequest(JSON.stringify(s));
  };

  deepExtend = (destination, source) => {
    for (var property in source) {
      if (typeof source[property] === 'object' &&
       source[property] !== null ) {
        destination[property] = destination[property] || (Array.isArray(source[property]) ? [] : {});
        destination[property] = this.deepExtend(destination[property], source[property]);
      } else {
        destination[property] = source[property];
      }
    }
    return destination;
  };

  prepareAfterLoad(survey) {
    let sv = this.deepExtend({}, survey);

    sv.pages.forEach(page => {
      if(!page.elements) return;
      page.elements.forEach(elem => {
        elem.type = elem.type.name;
      });
    });

    return sv;
  }

  prepareSurveyToSend = (survey) => {

    survey.author = {
      userName: this.props.userName,
      email: this.props.email,
    };
    var s = this.editor.survey;
    survey.triggers = s.triggers;
    survey.completeText = s.locCompleteText.values;
    survey.completedHtml = s.locCompletedHtml.values;
    survey.pageNextText = s.locPageNextText.values;
    survey.pagePrevText = s.locPagePrevText.values;
    survey.startSurveyText = s.locStartSurveyText.values;
    survey.title = s.locTitle.values;

    survey.requiredText = s.requiredText;
    survey.isSinglePage = s.isSinglePage;
    survey.firstPageIsStarted = s.firstPageIsStarted;
    survey.showCompletedPage = s.showCompletedPage;
    survey.showPrevButton = s.showPrevButton;
    survey.maxTimeToFinish = s.maxTimeToFinish;
    survey.maxTimeToFinishPage = s.maxTimeToFinishPage;
    survey.questionErrorLocation = s.questionErrorLocation;
    survey.questionTitleLocation = s.questionTitleLocation;
    survey.showQuestionNumbers = s.showQuestionNumbers;
    survey.showTimerPanelMode = s.showTimerPanelMode;

    const emptyString = {
      default:'',
    };

    for (let i = 0; i < survey.pages.length; i++) {
      const resPage = survey.pages[i];
      const edPage = s.pages[i];

      resPage.title = edPage.locTitle.values;
      resPage.visible = edPage.visible;
      resPage.visibleIf = edPage.visibleIf;

      for (let j = 0; j < resPage.elements.length; j++) {
        const resElem = resPage.elements[j];
        const edElem = edPage.elements[j];

        resElem.visibleIf = edElem.visibleIf;
        resElem.enableIf = edElem.enableIf;
        resElem.visible = edElem.visible;
        resElem.inputType = edElem.inputType;
        resElem.startWithNewLine = edElem.startWithNewLine;
        resElem.placeHolder = edElem.locPlaceHolder ? edElem.locPlaceHolder.values : emptyString;
        resElem.label = edElem.locLabel ? edElem.locLabel.values : emptyString;
        resElem.otherText = edElem.locOtherText ? edElem.locOtherText.values : emptyString;
        resElem.minRateDescription = edElem.locMinRateDescription ? edElem.locMinRateDescription.values : emptyString;
        resElem.maxRateDescription = edElem.locMaxRateDescription ? edElem.locMaxRateDescription.values : emptyString;
        resElem.title = edElem.locTitle.values;
        let name = resElem.type.charAt(0).toUpperCase() + resElem.type.slice(1);
        resElem.type = { name };

        resElem.choices = [];
        for (let i = 0; i < (edElem.choices||[]).length; i++) {
          resElem.choices.push({
            visibleIf: edElem.choices[i].visibleIf || '',
            enableIf: edElem.choices[i].enableIf || '',
            value: edElem.choices[i].value,
            text: edElem.choices[i].locText.values.default ? edElem.choices[i].locText.values : emptyString,
          });
        }
      }
    }

    return survey;
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
