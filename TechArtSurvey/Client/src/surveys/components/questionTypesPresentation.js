import { questionTypes } from '../questionTypes';

export const questionTypesArray = [
  {
    id : 1,
    name : questionTypes.SINGLE_ANSWER,
    text : 'Single answer',
  },
  {
    id : 2,
    name : questionTypes.MULTIPLE_ANSWER,
    text : 'Multiple answer',
  },
  {
    id : 3,
    name : questionTypes.TEXT_ANSWER,
    text : 'Text answer',
  },
  {
    id : 4,
    name : questionTypes.FILE_ANSWER,
    text : 'File answer',
  },
  {
    id : 5,
    name : questionTypes.STAR_RATING_ANSWER,
    text : 'Rating in stars',
  },
  {
    id : 6,
    name : questionTypes.SCALE_RATING_ANSWER,
    text : 'Rating in scale',
  },
];
