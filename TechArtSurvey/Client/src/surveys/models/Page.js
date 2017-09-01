export default class Page {
  constructor(title = '', questions = []) {
    this.title = title;
    this.questions = questions;
  }

  GetCopy(){
    let page = new Page();
    page.title = this.title;
    page.questions = this.questions.map(q => q.GetCopy());

    return page;
  }
}
