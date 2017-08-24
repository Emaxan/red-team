export default class Page {
  constructor(title = '', number = 1, questions = []) {
    this.title = title;
    this.number = number;
    this.questions = questions;
  }
}
