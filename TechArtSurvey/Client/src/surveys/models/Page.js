import Question from '../models/Question';

export default class Page {
  constructor(number = 1, title = null, questions = [new Question(0)]) {
    this.questions = questions;
    this.title = title === null
      ? 'Page ' + number
      : title;
  }

  getCopy(){
    let page = new Page();
    page.title = this.title;
    page.questions = this.questions.map(q => q.getCopy());

    return page;
  }
}
