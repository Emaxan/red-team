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
