import Question from '../models/Question';
import { questionTypes } from '../questionTypes';

export const changeType = (oldQuestion, type) => {
  if(oldQuestion.type == type) {
    return null;
  }
  var newQuestion = new Question(oldQuestion.id, oldQuestion.number, type, oldQuestion.text, oldQuestion.isRequired);
  if((oldQuestion.type == questionTypes.SINGLE_ANSWER
      || oldQuestion.type == questionTypes.MULTIPLE_ANSWER)
      && (type == questionTypes.SINGLE_ANSWER
      || type == questionTypes.MULTIPLE_ANSWER))
  {
    newQuestion.metaInfo = oldQuestion.metaInfo;
  }
  return newQuestion;
};

export const getLastId = (pages) => {
  var idList = [];
  pages.map((page) =>
    page.questions.map((question) => {
      idList.push(question.id);
    }));
  if(idList.length == 0) {
    return -1;
  }
  if(idList.length > 1) {
    idList.sort((a,b) => {
      if(a > b) {
        return 1;
      }
      return -1;
    });
  }
  return idList[idList.length - 1];
};