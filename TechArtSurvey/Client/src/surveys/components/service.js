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

export const isSurveyValid = (errors) => {
  if(errors.survey.title) {
    return false;
  }

  let isValid = true;
  errors.survey.pages.map(page => {
    if (page.title) {
      isValid = false;
      return;
    }
    if(page.questions) {
      isValid = false;
      return;
    }
  });

  return isValid;
};