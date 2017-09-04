export default class QuestionError {
  constructor(title = '', metaInfo = '') {
    this.title = title;
    this.metaInfo = metaInfo;
  }

  getCopy(){
    let errors = new QuestionError();
    errors.title = this.title;
    errors.metaInfo = this.metaInfo;

    return errors;
  }
}
