import {
  createFileQuestion,
  createTextQuestion,
  createScaleRatingQuestion,
  createStarRatingQuestion,
  createVariantQuestion,
} from './questionCreators';

export const questionsFactory = {
  SINGLE_ANSWER : createVariantQuestion,
  MULTIPLE_ANSWER : createVariantQuestion,
  FILE_ANSWER : createFileQuestion,
  TEXT_ANSWER : createTextQuestion,
  SCALE_RATING_ANSWER : createScaleRatingQuestion,
  STAR_RATING_ANSWER : createStarRatingQuestion,
};
