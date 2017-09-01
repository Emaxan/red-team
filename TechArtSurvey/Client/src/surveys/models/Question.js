import { defaultType } from '../questionTypes';

export default class Question {
  constructor(number, type = defaultType, title = '', isRequired = true, metaInfo = []) {
    this.number = number;
    this.type = type;
    this.title = title;
    this.isRequired = isRequired;
    this.metaInfo = metaInfo;
  }

  GetCopy(){
    let question = new Question();
    question.number = this.number;
    question.type = this.type;
    question.title = this.title;
    question.isRequired = this.isRequired;
    question.metaInfo = this.metaInfo.map(m => m);

    return question;
  }
}
