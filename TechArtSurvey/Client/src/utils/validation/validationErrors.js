import * as constants from './constants';

export const validationErrors = {
  TitleRequired : {
    id : constants.COMMON_TITLE_REQUIRED_ERROR_ID,
    message : 'Title is required',
  },

  UserNameRequired : {
    id : constants.USER_NAME_REQUIRED_ERROR_ID,
    message : 'Name is required',
  },

  UserNameMinLength : {
    id : constants.USER_NAME_MIN_LENGTH_ERROR_ID,
    message : `Name should have at least ${constants.USER_NAME_MIN_LENGTH} symbols`,
  },

  UserEmailRequired : {
    id : constants.USER_EMAIL_REQUIRED_ERROR_ID,
    message : 'Email is required',
  },

  UserEmailIncorrect : {
    id : constants.USER_EMAIL_INCORRECT_ERROR_ID,
    message : 'Email is incorrect',
  },

  UserPasswordRequired : {
    id : constants.USER_PASSWORD_REQUIRED_ERROR_ID,
    message : 'Password is required',
  },

  UserPasswordMinLength : {
    id : constants.USER_PASSWORD_MIN_LENGTH,
    message : `Password should have at least ${constants.USER_PASSWORD_MIN_LENGTH} symbols`,
  },

  UserConfirmationPasswordMustMatch : {
    id : constants.USER_CONFIRMATION_PASSWORD_MUST_MATCH_ERROR_ID,
    message : 'Passwords must match',
  },

  QuestionTitleRequired : {
    id : constants.QUESTION_TITLE_REQUIRED_ERROR_ID,
    message : 'Question title is required',
  },

  QuestionsRequired : {
    id : constants.QUESTIONS_REQUIRED_ERROR_ID,
    message : 'Page questions are required',
  },

  VariantsRequired : {
    id : constants.VARIANTS_REQUIRED_ERROR_ID,
    message : 'Variants are required',
  },
};
