import Question from '../models/Question';
import { questionTypes } from '../questionTypes';
import {
  VARIANTS_ARE_REQUIRED,
  TITLE_IS_REQUIRED,
} from './errors';

export const changeType = (oldQuestion, type) => {
  if (oldQuestion.type === type) {
    return null;
  }

  var newQuestion = new Question(oldQuestion.number, type, oldQuestion.title, oldQuestion.isRequired);
  if ((oldQuestion.type == questionTypes.SINGLE_ANSWER
      || oldQuestion.type == questionTypes.MULTIPLE_ANSWER)
      && (type == questionTypes.SINGLE_ANSWER
      || type == questionTypes.MULTIPLE_ANSWER))
  {
    let metaInfo = oldQuestion.metaInfo.map(m => m);
    newQuestion.metaInfo = metaInfo;
  }

  return newQuestion;
};

export const getLastNumber = (questions) => {
  var numberList = [];
  questions.map((question) => {
    numberList.push(question.number);
  });

  if (numberList.length === 0) {
    return -1;
  }

  if (numberList.length > 1) {
    numberList.sort((a,b) => {
      if (a > b) {
        return 1;
      }
      return -1;
    });
  }

  return numberList[numberList.length - 1];
};

const hasError = fieldError => fieldError != null;

export const isSurveyValid = (survey) => {
  if(hasError(survey.title)) {
    return false;
  }

  let isValid = true;

  survey.pages.map(page => {
    if (hasError(page.title)) {
      isValid = false;

      return;
    }
    page.questions.map(question => {
      if(hasError(question.title) || hasError(question.metaInfo)) {
        isValid = false;

        return;
      }
    });
  });

  return isValid;
};

export const validateMetaInfo = (question) => {
  if(question.type == questionTypes.TEXT_ANSWER || question.type == questionTypes.FILE_ANSWER) {
    return null;
  }
  if(question.metaInfo.length === 0) {
    return VARIANTS_ARE_REQUIRED;
  }
  return null;
};

export const validateTitle = (element) => {
  if(element.title.trim().length === 0) {
    return TITLE_IS_REQUIRED;
  }

  return null;
};

export const prepareSurvey = (survey) => {
  let newSurvey = {...survey};
  let newPages = survey.pages.map((page, index) => {
    let newQuestions = page.questions.map(q => {
      let variants = q.metaInfo.map(m => ({text : m}));
      let newQuestion = {
        title : q.title,
        variants : variants,
        number : q.number,
        type : {name : q.type},
        isRequired : q.isRequired,
      };
      return newQuestion;
    });
    let newPage = {...page};
    newPage.questions = newQuestions;
    newPage.number = index;
    return newPage;
  });
  newSurvey.pages = newPages;

  return newSurvey;
};