import React, { Component } from 'react';
import * as SurveyJSEditor from 'surveyjs-editor';
import * as SurveyKo from 'survey-knockout';
import 'surveyjs-editor/surveyeditor.css';
import './SurveyEditor.scss';

import 'jquery-ui/themes/base/all.css';
import 'select2/dist/css/select2.css';

import 'jquery-bar-rating/dist/themes/css-stars.css';
import 'jquery-bar-rating/dist/themes/fontawesome-stars.css';

import $ from 'jquery';
import 'jquery-ui/ui/widgets/datepicker.js';
import 'select2/dist/js/select2.js';
import 'jquery-bar-rating';

import 'icheck/skins/square/blue.css';

import * as widgets from 'surveyjs-widgets';

widgets.jquerybarrating(SurveyKo, $);
widgets.jqueryuidatepicker(SurveyKo, $);

class SurveyEditor extends Component {
  editor;
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
    $('.svd_commercial_container').remove();

    this.editor
      .onCanShowProperty
      .add(function (sender, options) {
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
  }
  render() {
    return <div id="surveyEditorContainer" />;
  }
  saveMySurvey = () => {
    // console.log(JSON.stringify(this.editor.text));
    console.log(JSON.parse(this.editor.text));
  };
}

export default SurveyEditor;