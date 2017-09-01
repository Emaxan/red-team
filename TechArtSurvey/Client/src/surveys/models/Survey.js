import Settings from './Settings';
import Page from './Page';

export default class Survey {
  constructor(title = '', settings = new Settings(), pages = [new Page()]) {
    this.title = title;
    this.settings = settings;
    this.pages = pages;
  }

  getCopy(){
    let survey = new Survey();
    survey.title = this.title;
    survey.settings = this.settings.getCopy();
    survey.pages = this.pages.map(p => p.getCopy());

    return survey;
  }
}
