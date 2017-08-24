export default class Settings {
  constructor(
    isAnonymous = false,
    hasQuestionNumbers = false,
    hasPageNumbers = false,
    isRandomOrdered = false,
    hasRequiredFieldsStars = false,
    hasProgressIndicator = false) {

    this.isAnonymous = isAnonymous;
    this.hasQuestionNumbers = hasQuestionNumbers;
    this.hasPageNumbers = hasPageNumbers;
    this.isRandomOrdered = isRandomOrdered;
    this.hasRequiredFieldsStars = hasRequiredFieldsStars;
    this.hasProgressIndicator = hasProgressIndicator;

  }
}
