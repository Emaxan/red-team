import React from 'react';

import { SingleQuestion } from './questions/SingleQuestion';
import { FileQuestion } from './questions/FileQuestion';
import { MultipleQuestion } from './questions/MultipleQuestion';
import { TextQuestion } from './questions/TextQuestion';
import { ScaleRatingQuestion } from './questions/ScaleRatingQuestion';
import { StarRatingQuestion } from './questions/StarRatingQuestion';

export const createSingleQuestion = (question, handleOnQuestionChange, handleOnEditingQuestionChange) =>
  <SingleQuestion
    question={question}
    handleOnQuestionChange = {handleOnQuestionChange}
    handleOnEditingQuestionChange = {handleOnEditingQuestionChange}
  />;

export const createMultipleQuestion = (question, handleOnQuestionChange, handleOnEditingQuestionChange) =>
  <MultipleQuestion
    key={question.id}
    question={question}
    handleOnQuestionChange = {handleOnQuestionChange}
    handleOnEditingQuestionChange = {handleOnEditingQuestionChange}
  />;

export const createFileQuestion = (question, handleOnQuestionChange, handleOnEditingQuestionChange) =>
  <FileQuestion
    key={question.id}
    question={question}
    handleOnQuestionChange = {handleOnQuestionChange}
    handleOnEditingQuestionChange = {handleOnEditingQuestionChange}
  />;

export const createTextQuestion = (question, handleOnQuestionChange, handleOnEditingQuestionChange) =>
  <TextQuestion
    key={question.id}
    question={question}
    handleOnQuestionChange = {handleOnQuestionChange}
    handleOnEditingQuestionChange = {handleOnEditingQuestionChange}
  />;

export const createScaleRatingQuestion = (question, handleOnQuestionChange, handleOnEditingQuestionChange) =>
  <ScaleRatingQuestion
    key={question.id}
    question={question}
    handleOnQuestionChange = {handleOnQuestionChange}
    handleOnEditingQuestionChange = {handleOnEditingQuestionChange}
  />;

export const createStarRatingQuestion = (question, handleOnQuestionChange, handleOnEditingQuestionChange) =>
  <StarRatingQuestion
    key={question.id}
    question={question}
    handleOnQuestionChange = {handleOnQuestionChange}
    handleOnEditingQuestionChange = {handleOnEditingQuestionChange}
  />;
