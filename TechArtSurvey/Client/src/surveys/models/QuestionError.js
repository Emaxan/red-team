export default class QuestionError {
  constructor(title = '', metaInfo = '') {
    this.title = title;
    this.metaInfo = metaInfo;
  }

  getCopy = () => {
    const errors = new QuestionError(
      this.title,
      this.metaInfo,
    );

    return errors;
  }
}
