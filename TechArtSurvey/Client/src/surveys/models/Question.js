import { defaultType } from '../questionTypes';

export default class Question {
  constructor(number, type = defaultType, title = '', isRequired = true, metaInfo = []) {
    this.number = number;
    this.type = type;
    this.title = title;
    this.isRequired = isRequired;
    this.metaInfo = metaInfo;
  }
}
