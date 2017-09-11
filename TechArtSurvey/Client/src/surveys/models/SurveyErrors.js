import PageErrors from './PageErrors';

export default class SurveyErrors {
  constructor(title = '', pageErrors = [new PageErrors()]) {
    this.title = title;
    this.pageErrors = pageErrors;
  }

  getCopy = () => {
    const errors = new SurveyErrors(
      this.title,
      this.pageErrors.map(pe => pe.getCopy()),
    );

    return errors;
  }
}
