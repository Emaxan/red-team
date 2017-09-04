import validator from 'validator';

import { validationErrors } from './validationErrors';
import ValidationResult from './validationResult';
import { questionTypes } from '../../surveys/questionTypes';

export const validateTitle = (title) => {
  let errors = [];

  if (validator.isEmpty(title)) {
    errors.push(validationErrors.QuestionTitleRequired);
  }

  return new ValidationResult(errors.length === 0, errors);
};

export const validateMetaInfo = (question) => {
  let errors = [];
  if(question.type == questionTypes.TEXT_ANSWER || question.type == questionTypes.FILE_ANSWER) {
    return new ValidationResult(errors.length === 0, errors);
  }
  if(question.metaInfo.length === 0) {
    errors.push(validationErrors.VariantsRequired);
  }

  return new ValidationResult(errors.length === 0, errors);
};