export default class Question {
  constructor(id, type, text='', isRequired=true, metaInfo='') {
    this.id = id;
    this.type = type;
    this.text = text;
    this.isRequired = isRequired;
    this.metaInfo = metaInfo;
  }
}