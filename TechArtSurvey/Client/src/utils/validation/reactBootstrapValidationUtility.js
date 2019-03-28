import {
  REACT_BOOTSTRAP_VALIDATION_STATE_SUCCESS,
  REACT_BOOTSTRAP_VALIDATION_STATE_ERROR,
} from './constants';

export const reactBootstrapValidationUtility = {
  setValidationState : (fieldName, errors, validationStates, validationInfo) => {
    if (validationInfo.isValid) {
      errors[fieldName] = null;
      validationStates[fieldName] = REACT_BOOTSTRAP_VALIDATION_STATE_SUCCESS;
    } else {
      errors[fieldName] = validationInfo.errors[0].message;
      validationStates[fieldName] = REACT_BOOTSTRAP_VALIDATION_STATE_ERROR;
    }
  },
};
