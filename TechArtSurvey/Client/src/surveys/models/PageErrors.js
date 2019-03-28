import QuestionError from './QuestionError';

export default class PageErrors {
  constructor(title = null, questionErrors = [new QuestionError()]) {
    this.title = title;
    this.questionErrors = questionErrors;
  }

  getCopy = () => {
    const errors = new PageErrors(
      this.title,
      this.questionErrors.map(qe => qe.getCopy()),
    );

    return errors;
  }
}
