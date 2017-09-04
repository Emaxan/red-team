import { defaultType } from '../questionTypes';
import { getDefaultMetaInfoByType } from '../components/service';

export default class Question {
  constructor(number, type = defaultType, title = '', isRequired = true, metaInfo = getDefaultMetaInfoByType(type)) {
    this.number = number;
    this.type = type;
    this.title = title;
    this.isRequired = isRequired;
    this.metaInfo = metaInfo;
  }

  getCopy(){
    let question = new Question();
    question.number = this.number;
    question.type = this.type;
    question.title = this.title;
    question.isRequired = this.isRequired;
    question.metaInfo = this.metaInfo.map(m => m);

    return question;
  }
}
