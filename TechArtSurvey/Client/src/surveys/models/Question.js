import { defaultType } from '../questionTypes';

export default class Question {
  constructor(id, type = defaultType, title = '', isRequired = true, metaInfo = []) {
    this.id = id;
    this.type = type;
    this.title = title;
    this.isRequired = isRequired;
    this.metaInfo = metaInfo;
  }
}
