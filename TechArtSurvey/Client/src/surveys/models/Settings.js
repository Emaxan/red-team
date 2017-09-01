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

  GetCopy(){
    let settings = new Settings();
    settings.isAnonymous = this.isAnonymous;
    settings.hasQuestionNumbers = this.hasQuestionNumbers;
    settings.hasPageNumbers = this.hasPageNumbers;
    settings.isRandomOrdered = this.isRandomOrdered;
    settings.hasRequiredFieldsStars = this.hasRequiredFieldsStars;
    settings.hasProgressIndicator = this.hasProgressIndicator;

    return settings;
  }
}
