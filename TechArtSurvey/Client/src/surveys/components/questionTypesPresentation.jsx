import {questionTypes} from '../questionTypes';
import {SingleQuestion} from './questions/SingleQuestion';
import  {FileQuestion} from './questions/FileQuestion';
import  {MultipleQuestion} from './questions/MultipleQuestion';
import  {TextQuestion} from './questions/TextQuestion';
import  {ScaleRatingQuestion} from './questions/ScaleRatingQuestion';
import  {StarRatingQuestion} from './questions/StarRatingQuestion';

import React from 'react';

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

const createSingleQuestion = (question, index, handleOnQuestionChange) =>
  <SingleQuestion
    key={question.id}
    question={question}
    number={index}
    handleOnQuestionChange = {handleOnQuestionChange}
  />;

const createMultipleQuestion = (question, index, handleOnQuestionChange) =>
  <MultipleQuestion
    key={question.id}
    question={question}
    number={index}
    handleOnQuestionChange = {handleOnQuestionChange}
  />;

const createFileQuestion = (question, index, handleOnQuestionChange) =>
  <FileQuestion
    key={question.id}
    question={question}
    number={index}
    handleOnQuestionChange = {handleOnQuestionChange}
  />;

const createTextQuestion = (question, index, handleOnQuestionChange) =>
  <TextQuestion
    key={question.id}
    question={question}
    number={index}
    handleOnQuestionChange = {handleOnQuestionChange}
  />;

const createScaleRatingQuestion = (question, index, handleOnQuestionChange) =>
  <ScaleRatingQuestion
    key={question.id}
    question={question}
    number={index}
    handleOnQuestionChange = {handleOnQuestionChange}
  />;

const createStarRatingQuestion = (question, index, handleOnQuestionChange) =>
  <StarRatingQuestion
    key={question.id}
    question={question}
    number={index}
    handleOnQuestionChange = {handleOnQuestionChange}
  />;

export const questionComponents = {
  SINGLE_ANSWER: createSingleQuestion,
  MULTIPLE_ANSWER: () => createMultipleQuestion,
  FILE_ANSWER: () => createFileQuestion,
  TEXT_ANSWER: () => createTextQuestion,
  SCALE_RATING_ANSWER: () => createScaleRatingQuestion,
  STAR_RATING_ANSWER: () => createStarRatingQuestion,
};