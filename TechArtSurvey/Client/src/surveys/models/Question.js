import { defaultType } from '../questionTypes';

export default class Question {
  constructor(id, number, type = defaultType, title = '', isRequired = true, metaInfo = []) {
    this._id = id;
    this._type = type;
    this._title = title;
    this._isRequired = isRequired;
    this._metaInfo = metaInfo;
    this._number = number;
  }

  get id() {
    return this._id;
  }

  get type() {
    return this._type;
  }

  get title() {
    return this._title;
  }

  get isRequired() {
    return this._isRequired;
  }

  get metaInfo() {
    return this._metaInfo;
  }

  get number() {
    return this._number;
  }

  set type(val) {
    this._type = val;
  }

  set title(val) {
    this._title = val;
  }

  set isRequired(val) {
    this._isRequired = val;
  }

  set metaInfo(val) {
    this._metaInfo = val;
  }

  set number(val) {
    this._number = val;
  }
}
