import Question from './Question';
import {questionTypes} from '../questionTypes';

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