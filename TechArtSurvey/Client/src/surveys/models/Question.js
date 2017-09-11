import { defaultType } from '../questionTypes';
import { getDefaultMetaInfoByType } from '../components/service';

export default class Question {
  constructor(number, type = defaultType, title = '', isRequired = true, metaInfo = getDefaultMetaInfoByType(type)) {
    this.number = number;
    this.type = type;
    this.title = title;
    this.isRequired = isRequired;
    this.metaInfo = metaInfo;
  }

  getCopy = () => {
    const question = new Question(
      this.number,
      this.type,
      this.title,
      this.isRequired,
      this.metaInfo.map(m => m),
    );

    return question;
  }
}
