import validator from 'validator';

import { validationErrors } from './validationErrors';
import ValidationResult from './validationResult';

export const validateTitle = (title) => {
  let errors = [];

  if (validator.isEmpty(title)) {
    errors.push(validationErrors.QuestionTitleRequired);
  }

  return new ValidationResult(errors.length === 0, errors);
};

export const validateMetaInfo = (metaInfo) => {
  let errors = [];
  if(validator.isEmpty(metaInfo)) {
    errors.push(validationErrors.VariantsRequired);

    return new ValidationResult(errors.length === 0, errors);
  }
  metaInfo.map(option => {
    if(!option || option == '') {
      errors.push(validationErrors.VariantsRequired);

      return new ValidationResult(errors.length === 0, errors);
    }
  });

  return new ValidationResult(errors.length === 0, errors);
};