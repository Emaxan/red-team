import React from 'react';

import { SingleQuestion } from './questions/SingleQuestion';
import { FileQuestion } from './questions/FileQuestion';
import { MultipleQuestion } from './questions/MultipleQuestion';
import { TextQuestion } from './questions/TextQuestion';
import { ScaleRatingQuestion } from './questions/ScaleRatingQuestion';
import { StarRatingQuestion } from './questions/StarRatingQuestion';


export const createSingleQuestion = (question, handleOnQuestionUpdate) =>
  <SingleQuestion
    key={question.id}
    question={question}
    handleOnQuestionUpdate={handleOnQuestionUpdate}
  />;

export const createMultipleQuestion = (question, handleOnQuestionUpdate) =>
  <MultipleQuestion
    key={question.id}
    question={question}
    handleOnQuestionUpdate={handleOnQuestionUpdate}
  />;

export const createFileQuestion = (question, handleOnQuestionUpdate) =>
  <FileQuestion
    key={question.id}
    question={question}
    handleOnQuestionUpdate={handleOnQuestionUpdate}
  />;

export const createTextQuestion = (question, handleOnQuestionUpdate) =>
  <TextQuestion
    key={question.id}
    question={question}
    handleOnQuestionUpdate={handleOnQuestionUpdate}
  />;

export const createScaleRatingQuestion = (question, handleOnQuestionUpdate) =>
  <ScaleRatingQuestion
    key={question.id}
    question={question}
    handleOnQuestionUpdate={handleOnQuestionUpdate}
  />;

export const createStarRatingQuestion = (question, handleOnQuestionUpdate) =>
  <StarRatingQuestion
    key={question.id}
    question={question}
    handleOnQuestionUpdate={handleOnQuestionUpdate}
  />;
