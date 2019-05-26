import * as SurveyKo from 'survey-knockout';

export const validateSurvey = (surveyFromJson, survey) => {
  const validation = {
    isValid: true,
    customErrors: [],
  };

  if (!surveyFromJson.title.default) {
    validation.isValid = false;
    validation.customErrors.push('Survey title can\'t be empty');
  }
  for (let pageIndex = 0; pageIndex < surveyFromJson.pages.length; pageIndex++) {
    const pageFromJson = surveyFromJson.pages[pageIndex];
    const page = survey.pages[pageIndex];
    for (let pageProp in pageFromJson) {
      let value = pageProp === 'title' ? pageFromJson[pageProp].default : pageFromJson[pageProp];
      let validationElement = {
        value: value,
        propertyName: pageProp,
        error: '',
        question: false,
      };
      validator(validationElement);
      if (validationElement.error !== '') {
        validation.isValid = false;
        validation.customErrors.push( 'Page ' + validationElement.error);
      }
    }
    for (let questionIndex = 0; questionIndex < pageFromJson.elements.length; questionIndex++) {
      const questionFromJson = pageFromJson.elements[questionIndex];
      const question = page.elements[questionIndex];
      for (let questionProp in questionFromJson) {
        let value = questionFromJson[questionProp];
        let validationElement = {
          value: value,
          propertyName: questionProp,
          error: '',
          question: true,
          type: questionFromJson.type.name,
        };
        validator(validationElement);
        if (validationElement.error !== '') {
          validation.isValid = false;
          question.errors.push(new SurveyKo.SurveyError(validationElement.error));
        }
      }
    }
  }

  return validation;
};

const properties = {
  Text: ['placeHolder', 'name', 'title'],
  Datepicker: ['placeHolder', 'name', 'title'],
  Dropdown: ['name', 'title', 'optionsCaption', 'choices', 'otherText'],
  Matrix: ['name', 'title', 'columns', 'rows', 'text', 'value'],
  Barrating: ['name', 'title', 'choices'],
  Boolean: ['name', 'title', 'label'],
  Rating: ['name', 'title', 'minRateDescription', 'maxRateDescription', 'choices', 'text', 'value'],
  Comment: ['name', 'title', 'rows', 'placeHolder'],
  Checkbox: ['name', 'title', 'colCount', 'choices', 'otherText', 'text', 'value'],
  Radiogroup: ['name', 'title', 'colCount', 'choices', 'otherText', 'text', 'value'],
};

export const validator = (opt) => {
  // const validationOnSave = opt.obj === undefined;
  if(opt.question && !properties[opt.type].includes(opt.propertyName)) return;
  switch(opt.propertyName){
  case 'title':
  case 'name':
  case 'otherText':
  case 'text':
  case 'value':
  case 'colCount':
  case 'optionsCaption':
  case 'placeHolder':
  case 'minRateDescription':
  case 'maxRateDescription':
  case 'label':
    if (isEmptyString(opt.value)) {
      opt.error = `${opt.propertyName} can't be empty`;
    }
    break;
  case 'choices':
    if(opt.value.length === 0) opt.error = 'You should add at least one choice';
    break;
  case 'columns':
    if(opt.value.length === 0) opt.error = 'You should add at least one column';
    break;
  case 'rows':
    if (Array.isArray(opt.value)) {
      if(opt.value.length === 0) opt.error = 'You should add at least one row';
    } else {
      if (isEmptyString(opt.value)) {
        opt.error = `${opt.propertyName} can't be empty`;
      }
    }
    break;
  default:
    break;
  }
};

const isEmptyString = (string) => {
  if (string === undefined) return true;
  if (typeof string === 'object') if (!string.default || string.default === '') return true;
  return string === '';
};
