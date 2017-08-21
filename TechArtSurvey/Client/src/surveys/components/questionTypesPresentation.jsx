import {questionTypes} from '../questionTypes';
import {SingleQuestion} from './questions/SingleQuestion';
import  {FileQuestion} from './questions/FileQuestion';
import  {MultipleQuestion} from './questions/MultipleQuestion';
import  {TextQuestion} from './questions/TextQuestion';
import  {ScaleRatingQuestion} from './questions/ScaleRatingQuestion';
import  {StarRatingQuestion} from './questions/StarRatingQuestion';

export const questionTypesArray = [
  {
    id: 1,
    img: '../images/single.jpg',
    name: questionTypes.SINGLE_ANSWER,
  },
  {
    id: 2,
    img: '../images/multiple.jpg',
    name: questionTypes.MULTIPLE_ANSWER,
  },
  {
    id: 3,
    img: '../images/text.jpg',
    name: questionTypes.TEXT_ANSWER,
  },
  {
    id: 4,
    img: '../images/file.jpg',
    name: questionTypes.FILE_ANSWER,
  },
  {
    id: 5,
    img: '../images/star.jpg',
    name: questionTypes.STAR_RATING_ANSWER,
  },
  {
    id: 6,
    img: '../images/scale.jpg',
    name: questionTypes.SCALE_RATING_ANSWER,
  },
];

export const questionComponents = {
  SINGLE_ANSWER: () => SingleQuestion(),
  MULTIPLE_ANSWER: () => MultipleQuestion(),
  FILE_ANSWER: () => FileQuestion(),
  TEXT_ANSWER: () => TextQuestion(),
  SCALE_RATING_ANSWER: () => ScaleRatingQuestion(),
  STAR_RATING_ANSWER: () => StarRatingQuestion(),
};