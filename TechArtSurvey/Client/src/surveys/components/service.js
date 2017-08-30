import Question from '../models/Question';
import { questionTypes } from '../questionTypes';

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