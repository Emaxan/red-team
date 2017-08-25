import React, { Component } from 'react';
import { DragDropContext } from 'react-dnd';
import update from 'react/lib/update';
import HTML5Backend from 'react-dnd-html5-backend';
import Question from './Question';

@DragDropContext(HTML5Backend)
export default class QuestionList extends Component {
  constructor(props) {
    super(props);

    this.state = {
      questions: [{
        id: 1,
        text: 'Q1',
      }, {
        id: 2,
        text: 'Q2',
      }, {
        id: 3,
        text: 'Q3',
      }],
    };
  }

  moveQuestion = (dragIndex, hoverIndex) => {
    const { questions } = this.state;
    const dragQuestion = questions[dragIndex];

    this.setState(update(this.state, {
      questions: {
        $splice: [
          [dragIndex, 1],
          [hoverIndex, 0, dragQuestion],
        ],
      },
    }));
  }

  render() {
    const { questions } = this.state;

    return (
      <div>
        {questions.map((question, i) => (
          <Question
            key={question.id}
            index={i}
            id={question.id}
            text={question.text}
            moveQuestion={this.moveQuestion}
          />
        ))}
      </div>
    );
  }
}
