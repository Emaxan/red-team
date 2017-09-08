import React, { Component } from 'react';
import { Button, Glyphicon, FormGroup, Col, Panel } from 'react-bootstrap';
import PropTypes from 'prop-types';
import { DropTarget } from 'react-dnd';

import { questionsFactory } from '../../questionsFactory';
import Question from '../../../models/Question';
import QuestionError from '../../../models/QuestionError';
import { isQuestionValid } from '../../service';
import { DND_ITEM_QUESTION } from './constants';

import './NonEditingQuestionWrapper.scss';
import './Wrapper.scss';

class NonEditingQuestionWrapper extends Component {
  constructor(props){
    super(props);

    this.question = this.props.question.getCopy();
    this.errors = this.props.errors.getCopy();
  }

  componentWillReceiveProps = (props) => {
    this.question = props.question.getCopy();
    this.errors = props.errors.getCopy();
  }

  handleOnEditClick = () => {
    this.props.handleOnEditingQuestionNumberChange(this.question.number);
  }

  render = () => {
    return this.props.connectDropTarget(
      <div ref={node => (this.node = node)}>
        <Panel  className={isQuestionValid(this.errors) ? '' : 'panel-has-error'}>
          <FormGroup className="title">
            <Col sm={10} smOffset={1}>
              {
                this.props.question.title
              }
            </Col>
          </FormGroup>
          <div className="question-wrapper">
            {
              questionsFactory[this.question.type](
                this.question,
                null,
                {
                  isValid : isQuestionValid(this.question),
                  errors : this.errors,
                },
              )
            }
            <Button onClick={this.handleOnEditClick} className="question-wrapper__edit">
              <Glyphicon glyph="pencil" />
            </Button>
          </div>
        </Panel>
      </div>,
    );
  }
}

NonEditingQuestionWrapper.propTypes = {
  index : PropTypes.number.isRequired,
  question : PropTypes.instanceOf(Question).isRequired,
  errors : PropTypes.instanceOf(QuestionError).isRequired,
  moveQuestion : PropTypes.func.isRequired,
  handleOnEditingQuestionNumberChange : PropTypes.func.isRequired,
  connectDropTarget : PropTypes.func.isRequired,
};

const nonEditingQuestionWrapperSpec = {
  hover(props, monitor, component) {
    const dragIndex = monitor.getItem().index;
    const hoverIndex = props.index;

    if (dragIndex === hoverIndex) {
      return;
    }

    const hoverBoundingRect = component.node.getBoundingClientRect();
    const hoverMiddleY = (hoverBoundingRect.bottom - hoverBoundingRect.top) / 2;
    const clientOffset = monitor.getClientOffset();
    const hoverClientY = clientOffset.y - hoverBoundingRect.top;

    if (dragIndex < hoverIndex && hoverClientY < hoverMiddleY) {
      return;
    }

    if (dragIndex > hoverIndex && hoverClientY > hoverMiddleY) {
      return;
    }

    props.moveQuestion(dragIndex, hoverIndex);
    monitor.getItem().index = hoverIndex;
  },
};

const nonEditingQuestionWrapperCollect = (connect) => ({
  connectDropTarget : connect.dropTarget(),
});

export default DropTarget(DND_ITEM_QUESTION, nonEditingQuestionWrapperSpec, nonEditingQuestionWrapperCollect)(NonEditingQuestionWrapper);
