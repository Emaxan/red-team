import PageErrors from './PageErrors';

export default class SurveyErrors {
  constructor(title = '', pageErrors = [new PageErrors()]) {
    this.title = title;
    this.pageErrors = pageErrors;
  }

  getCopy(){
    let errors = new SurveyErrors();
    errors.title = this.title;
    errors.pageErrors = this.pageErrors.map(pe => pe.getCopy());

    return errors;
  }
}
