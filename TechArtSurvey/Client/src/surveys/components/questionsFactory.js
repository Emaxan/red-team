import {
  createSingleQuestion,
  createMultipleQuestion,
  createFileQuestion,
  createTextQuestion,
  createScaleRatingQuestion,
  createStarRatingQuestion,
} from './questionCreators';

export const questionsFactory = {
  SINGLE_ANSWER: createSingleQuestion,
  MULTIPLE_ANSWER:createMultipleQuestion,
  FILE_ANSWER: createFileQuestion,
  TEXT_ANSWER:  createTextQuestion,
  SCALE_RATING_ANSWER: createScaleRatingQuestion,
  STAR_RATING_ANSWER:  createStarRatingQuestion,
};