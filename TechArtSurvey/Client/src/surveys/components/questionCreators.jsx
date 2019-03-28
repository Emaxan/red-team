import React from 'react';

import { VariantQuestion } from './questions/VariantQuestion';
import { FileQuestion } from './questions/FileQuestion';
import { TextQuestion } from './questions/TextQuestion';
import { ScaleRatingQuestion } from './questions/ScaleRatingQuestion';
import { StarRatingQuestion } from './questions/StarRatingQuestion';


export const createVariantQuestion = (question, handleOnQuestionUpdate, props={}) => {
  return (<VariantQuestion
    key={question.id}
    question={question}
    handleOnQuestionUpdate={handleOnQuestionUpdate}
    {...props}
  />);
};

export const createFileQuestion = (question, handleOnQuestionUpdate, props={}) =>
  <FileQuestion
    key={question.id}
    question={question}
    handleOnQuestionUpdate={handleOnQuestionUpdate}
    {...props}
  />;

export const createTextQuestion = (question, handleOnQuestionUpdate, props={}) =>
  <TextQuestion
    key={question.id}
    question={question}
    handleOnQuestionUpdate={handleOnQuestionUpdate}
    {...props}
  />;

export const createScaleRatingQuestion = (question, handleOnQuestionUpdate, props={}) =>
  <ScaleRatingQuestion
    key={question.id}
    question={question}
    handleOnQuestionUpdate={handleOnQuestionUpdate}
    {...props}
  />;

export const createStarRatingQuestion = (question, handleOnQuestionUpdate, props={}) =>
  <StarRatingQuestion
    key={question.id}
    question={question}
    handleOnQuestionUpdate={handleOnQuestionUpdate}
    {...props}
  />;
