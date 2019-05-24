export class EditorUtils {
  static deepExtend = (destination, source) => {
    for (var property in source) {
      if (typeof source[property] === 'object' &&
       source[property] !== null ) {
        destination[property] = destination[property] || (Array.isArray(source[property]) ? [] : {});
        destination[property] = EditorUtils.deepExtend(destination[property], source[property]);
      } else {
        destination[property] = source[property];
      }
    }
    return destination;
  };

  static prepareAfterLoad = (survey, pass = false) => {
    let sv = EditorUtils.deepExtend({}, survey);
    sv.pages.sort((a, b) => a.number - b.number);

    sv.pages.forEach(page => {
      if(!page.elements) return;
      page.elements.sort((a, b) => a.number - b.number);
      page.elements.forEach(elem => {
        if (typeof(elem.type) === 'string') return;
        elem.type = elem.type.name.toLowerCase();
      });
      if (pass) {
        page.questions = page.elements;
        delete page.elements;
      }
    });

    return sv;
  };

  static prepareSurveyToSend = (survey, s) => {
    const emptyString = {
      default:'',
    };

    survey.triggers = s.triggers;
    survey.locale = survey.locale || 'en';
    survey.completeText = s.locCompleteText.values.default ? s.locCompleteText.values : emptyString;
    survey.completedHtml = s.locCompletedHtml.values.default ? s.locCompletedHtml.values : emptyString;
    survey.pageNextText = s.locPageNextText.values.default ? s.locPageNextText.values : emptyString;
    survey.pagePrevText = s.locPagePrevText.values.default ? s.locPagePrevText.values : emptyString;
    survey.startSurveyText = s.locStartSurveyText.values.default ? s.locStartSurveyText.values : emptyString;
    survey.title = s.locTitle.values.default ? s.locTitle.values : emptyString;
    survey.createdDate = (new Date()).toISOString();
    survey.startDate = (new Date()).toISOString();
    survey.endDate = (new Date()).toISOString();

    survey.questionsOrder = s.questionsOrder;
    survey.showNavigationButtons = s.showNavigationButtons;
    survey.showProgressBar = s.showProgressBar;
    survey.showTimerPanel = s.showTimerPanel;
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

    for (let i = 0; i < survey.pages.length; i++) {
      const resPage = survey.pages[i];
      const edPage = s.pages[i];

      resPage.title = edPage.locTitle.values.default ? edPage.locTitle.values : emptyString;
      resPage.visible = edPage.visible;
      resPage.visibleIf = edPage.visibleIf;
      resPage.questionsOrder = edPage.questionsOrder;
      resPage.number = i;

      for (let j = 0; j < resPage.elements.length; j++) {
        const resElem = resPage.elements[j];
        const edElem = edPage.elements[j];

        resElem.number = j;
        resElem.colCount = edElem.colCount;
        resElem.choicesOrder = edElem.choicesOrder;
        resElem.visibleIf = edElem.visibleIf;
        resElem.enableIf = edElem.enableIf;
        resElem.visible = edElem.visible;
        resElem.inputType = edElem.inputType;
        resElem.startWithNewLine = edElem.startWithNewLine;
        resElem.optionsCaption = edElem.locOptionsCaption ? edElem.locOptionsCaption.values : emptyString;
        resElem.placeHolder = edElem.locPlaceHolder ? edElem.locPlaceHolder.values : emptyString;
        resElem.label = edElem.locLabel ? edElem.locLabel.values : emptyString;
        resElem.otherText = edElem.locOtherText ? edElem.locOtherText.values : emptyString;
        resElem.minRateDescription = edElem.locMinRateDescription ? edElem.locMinRateDescription.values : emptyString;
        resElem.maxRateDescription = edElem.locMaxRateDescription ? edElem.locMaxRateDescription.values : emptyString;
        resElem.title = edElem.locTitle.values;
        let name = resElem.type.charAt(0).toUpperCase() + resElem.type.slice(1);
        resElem.type = { name };

        resElem.choices = [];
        for (let k = 0; k < (edElem.choices||[]).length; k++) {
          resElem.choices.push({
            number: k,
            visibleIf: edElem.choices[k].visibleIf || '',
            enableIf: edElem.choices[k].enableIf || '',
            value: edElem.choices[k].value,
            text: edElem.choices[k].locText.values.default ? edElem.choices[k].locText.values : emptyString,
          });
        }

        resElem.columns = [];
        for (let k = 0; k < (edElem.columns||[]).length; k++) {
          resElem.columns.push({
            number: k,
            visibleIf: edElem.columns[k].visibleIf || '',
            enableIf: edElem.columns[k].enableIf || '',
            value: edElem.columns[k].value,
            text: edElem.columns[k].locText.values.default ? edElem.columns[k].locText.values : emptyString,
          });
        }
        if (Array.isArray(edElem.rows)) {
          resElem.rows = [];
          for (let k = 0; k < (edElem.rows||[]).length; k++) {
            resElem.rows.push({
              number: k,
              visibleIf: edElem.rows[k].visibleIf || '',
              enableIf: edElem.rows[k].enableIf || '',
              value: edElem.rows[k].value,
              text: edElem.rows[k].locText.values.default ? edElem.rows[k].locText.values : emptyString,
            });
          }
        }
      }
    }

    return survey;
  };
}
