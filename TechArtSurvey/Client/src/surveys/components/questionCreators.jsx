import React from 'react';

import { SingleQuestion } from './questions/SingleQuestion';
import { FileQuestion } from './questions/FileQuestion';
import { MultipleQuestion } from './questions/MultipleQuestion';
import { TextQuestion } from './questions/TextQuestion';
import { ScaleRatingQuestion } from './questions/ScaleRatingQuestion';
import { StarRatingQuestion } from './questions/StarRatingQuestion';

export const createSingleQuestion = (question, handleOnQuestionChange) =>
  <SingleQuestion
    key={question.id}
    question={question}
    handleOnQuestionChange={handleOnQuestionChange}
  />;

export const createMultipleQuestion = (question, handleOnQuestionChange) =>
  <MultipleQuestion
    key={question.id}
    question={question}
    handleOnQuestionChange={handleOnQuestionChange}
  />;

export const createFileQuestion = (question, handleOnQuestionChange) =>
  <FileQuestion
    key={question.id}
    question={question}
    handleOnQuestionChange={handleOnQuestionChange}
  />;

export const createTextQuestion = (question, handleOnQuestionChange) =>
  <TextQuestion
    key={question.id}
    question={question}
    handleOnQuestionChange={handleOnQuestionChange}
  />;

export const createScaleRatingQuestion = (question, handleOnQuestionChange) =>
  <ScaleRatingQuestion
    key={question.id}
    question={question}
    handleOnQuestionChange={handleOnQuestionChange}
  />;

export const createStarRatingQuestion = (question, handleOnQuestionChange) =>
  <StarRatingQuestion
    key={question.id}
    question={question}
    handleOnQuestionChange={handleOnQuestionChange}
  />;
