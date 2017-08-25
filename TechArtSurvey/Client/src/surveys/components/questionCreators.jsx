import React from 'react';

import { SingleQuestion } from './questions/SingleQuestion';
import { FileQuestion } from './questions/FileQuestion';
import { MultipleQuestion } from './questions/MultipleQuestion';
import { TextQuestion } from './questions/TextQuestion';
import { ScaleRatingQuestion } from './questions/ScaleRatingQuestion';
import { StarRatingQuestion } from './questions/StarRatingQuestion';


export const createSingleQuestion = (question, handleOnQuestionUpdate, props={}) => {
  return (<SingleQuestion
    key={question.id}
    question={question}
    handleOnQuestionUpdate={handleOnQuestionUpdate}
    {...props}
  />);
};

export const createMultipleQuestion = (question, handleOnQuestionUpdate, props={}) =>
  <MultipleQuestion
    key={question.id}
    question={question}
    handleOnQuestionUpdate={handleOnQuestionUpdate}
    {...props}
  />;

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
