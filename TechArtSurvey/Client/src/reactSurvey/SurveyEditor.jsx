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
      showJSONEditorTab: true ,	//Set this option to false to hide the JSON Tab.
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
    if(!survey.triggers) survey.triggers = [];
    var s = this.editor.translation.survey;
    survey.completeText = s.locCompleteText.values.default?s.locCompleteText.values:{default:survey.completeText||''};
    survey.completedHtml = s.locCompletedHtml.values.default?s.locCompletedHtml.values:{default:survey.completedHtml||''};
    survey.pageNextText = s.locPageNextText.values.default?s.locPageNextText.values:{default:survey.pageNextText||''};
    survey.pagePrevText = s.locPagePrevText.values.default?s.locPagePrevText.values:{default:survey.pagePrevText||''};
    survey.startSurveyText = s.locStartSurveyText.values.default?s.locStartSurveyText.values:{default:survey.startSurveyText||''};
    survey.title = s.locTitle.values.default?s.locTitle.values:{default:survey.title||''};

    if(!survey.requiredText) survey.requiredText = '*';
    if(!survey.isSinglePage) survey.isSinglePage = false;
    if(!survey.firstPageIsStarted) survey.firstPageIsStarted = false;
    if(!survey.showCompletedPage) survey.showCompletedPage = true;
    if(!survey.showPrevButton) survey.showPrevButton = true;
    if(!survey.maxTimeToFinish) survey.maxTimeToFinish = 0;
    if(!survey.maxTimeToFinishPage) survey.maxTimeToFinishPage = 0;
    survey.pages.forEach(page => {
      if(!page.title.default) page.title = {default:page.title};
      if(!page.visibleIf) page.visibleIf = '';
      if(!page.visible) page.visible = true;
      page.elements.forEach(elem => {
        if(!elem.visibleIf) elem.visibleIf = '';
        if(!elem.enableIf) elem.enableIf = '';
        if(!elem.visible) elem.visible = true;
        if(!elem.inputType) elem.inputType = 'text';
        if(!elem.startWithNewLine) elem.startWithNewLine = true;
        if(!elem.placeHolder) elem.placeHolder = {default:''};
        else if(!elem.placeHolder.default) elem.placeHolder = {default:elem.placeHolder};
        if(!elem.label) elem.label = {default:''};
        else if(!elem.label.default) elem.label = {default:elem.label};
        if(!elem.otherText) elem.otherText = {default:''};
        else if(!elem.otherText.default) elem.otherText = {default:elem.otherText};
        if(!elem.minRateDescription) elem.minRateDescription = {default:''};
        else if(!elem.minRateDescription.default) elem.minRateDescription = {default:elem.minRateDescription};
        if(!elem.maxRateDescription) elem.maxRateDescription = {default:''};
        else if(!elem.maxRateDescription.default) elem.maxRateDescription = {default:elem.maxRateDescription};
        if(!elem.title) elem.title = {default:''};
        else if(!elem.title.default) elem.title = {default:elem.title};
        let t = elem.type.charAt(0).toUpperCase() + elem.type.slice(1);
        elem.type = {name:t};
        if(elem.choices) this.checkChoices(elem.choices);
        else elem.choices = [];
      });
    });

    return survey;
  }

  checkChoices(choices) {
    if(choices.length==0) return [];
    if(choices[0].value) {
      choices.forEach(choice => {
        if(!choice.text) choice.text = {default:choice.value};
        else if(!choice.text.default) choice.text = {default:choice.text};
      });
    } else {
      let ch = choices;
      choices.length = 0;
      ch.forEach(c => {
        choices.push({default: c});
      });
    }
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