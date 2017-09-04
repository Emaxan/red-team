export default class Page {
  constructor(number = 1, title = null, questions = []) {
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
