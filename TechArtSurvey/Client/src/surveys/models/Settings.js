export default class Settings {
  constructor(isAnonymous, hasQuestionNumbers, hasPageNumbers, isRandomOrdered, hasRequiredFieldsStars, hasProgressIndicator) {
    this.isAnonymous = isAnonymous;
    this.hasPageNumbers = hasPageNumbers;
    this.isRandomOrdered = isRandomOrdered;
    this.hasRequiredFieldsStars = hasRequiredFieldsStars;
    this.hasProgressIndicator = hasProgressIndicator;
  }
}
