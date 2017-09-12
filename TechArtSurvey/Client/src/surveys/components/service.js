import Question from '../models/Question';
import { questionTypes, defaultType } from '../questionTypes';
import QuestionError from '../models/QuestionError';

export const changeQuestionType = (oldQuestion, type) => {
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

const isNotNull = fieldError => fieldError !== null;

export const isQuestionValid = questionErrors => questionErrors.title === null && questionErrors.metaInfo === null;

export const isPageValid = (pageErrors) => {
  if (isNotNull(pageErrors.title) || pageErrors.questionErrors.length === 0) {
    return false;
  }

  let isValid = true;
  pageErrors.questionErrors.map(qe => {
    if (isNotNull(qe.title) || isNotNull(qe.metaInfo)) {
      isValid = false;
    }
  });

  return isValid;
};

export const isSurveyValid = (surveyErrors) => {
  if (isNotNull(surveyErrors.title)) {
    return false;
  }

  let isValid = true;

  surveyErrors.pageErrors.map(pe => {
    if (!isPageValid(pe)) {
      isValid = false;
    }
  });

  return isValid;
};

export const prepareSurveyForRequest = (survey) => {
  let newSurvey = survey.getCopy();

  let newPages = survey.pages.map((page, index) => {
    let newQuestions = page.questions.map(q => {
      return {
        title : q.title,
        variants : q.metaInfo.map(m => ({ text : m })),
        number : q.number,
        type : { name : q.type },
        isRequired : q.isRequired,
      };
    });

    let newPage = { ...page };
    newPage.questions = newQuestions;
    newPage.number = index;

    return newPage;
  });

  newSurvey.pages = newPages;

  return newSurvey;
};

export const getDefaultMetaInfoByType = (type) => {
  switch (type) {
  case questionTypes.SINGLE_ANSWER:
  case questionTypes.MULTIPLE_ANSWER:
    return [ '' ];

  default:
    return [];
  }
};

export const getDefaultErrorByType = (type = defaultType) => {
  switch (type) {
  case questionTypes.SINGLE_ANSWER:
  case questionTypes.MULTIPLE_ANSWER:
    return new QuestionError();

  default:
    return new QuestionError('', null);
  }
};
