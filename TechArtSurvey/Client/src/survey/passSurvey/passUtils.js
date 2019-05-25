export const prepareResponseToSend = (response) => {
  let newResponse = {
    answers: [],
    surveyVersion: {
      surveyId: response.surveyId,
      number: response.surveyVersion,
    },
    passedDate: new Date(Date.now()).toISOString(),
    user: {
      userName: response.userName,
      email: response.email,
    },
  };
  const { survey } = response;
  const questions = survey.pages.flatMap((p) => p.elements);
  for (const key in response.data) {
    if(key.endsWith('-Comment')) {
      const questionName = key.substring(0, key.length - '-Comment'.length);
      assignCommentToQuestion(questionName, response.data[key], newResponse.answers);
    } else {
      const question = getQuestionByName(key, questions);
      const answer = generateResponseByQuestionType(key, response.data[key], question);
      if (answer) newResponse.answers.push(answer);
    }
  }

  return newResponse;
};

const getQuestionByName = (name, questions) => {
  for (let i = 0; i < questions.length; i++) {
    const question = questions[i];
    if (question.name === name) {
      return question;
    }
  }
};

const generateResponseByQuestionType = (name, value, question) => {
  const retValue = {
    question: {
      name,
    },
  };
  console.log(question);
  switch(question.koTemplateName()) {
  case 'survey-widget-datepicker':
  case 'survey-question-boolean':
  case 'survey-question-comment':
  case 'survey-question-text':
    retValue.value = value;
    break;
  case 'survey-question-radiogroup':
  case 'survey-question-dropdown':
  case 'survey-question-rating':
    retValue.variants = [{value}];
    break;
  case 'survey-question-checkbox':
    retValue.variants = value.map(val => ({value: val}));
    break;
  case 'survey-question-matrix':
    retValue.variants = [];
    for (const key in value ) {
      retValue.variants.push({value: `${key}.${value[key]}`});
    }
    break;
  default:
    return null;
  }

  return retValue;
};

const assignCommentToQuestion = (questionName, comment, answers) => {
  for (let i = 0; i < answers.length; i++) {
    const answer = answers[i];
    if(answer.question.name === questionName) {
      answer.value = comment;
      return;
    }
  }
};
