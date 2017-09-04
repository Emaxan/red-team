import QuestionError from './QuestionError';

export default class PageErrors {
  constructor(title = null, questionErrors = [new QuestionError()]) {
    this.title = title;
    this.questionErrors = questionErrors;
  }

  getCopy(){
    let errors = new PageErrors();
    errors.title = this.title;
    errors.questionErrors = this.questionErrors.map(qe => qe.getCopy());

    return errors;
  }
}
