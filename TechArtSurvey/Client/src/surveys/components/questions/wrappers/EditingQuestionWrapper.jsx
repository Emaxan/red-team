import React, { Component } from 'react';
import { Panel, Button, Checkbox, ButtonGroup, Glyphicon, ControlLabel, FormControl, FormGroup, Col } from 'react-bootstrap';
import PropTypes from 'prop-types';
import { DragSource } from 'react-dnd';

import { questionsFactory } from '../../questionsFactory';
import Question from '../../../models/Question';
import QuestionError from '../../../models/QuestionError';
import { validateTitle } from '../../../../utils/validation/questionValidation';
import { reactBootstrapValidationUtility as rbValidationUtility } from '../../../../utils/validation/reactBootstrapValidationUtility';
import { isQuestionValid, changeQuestionType, changeQuestionError } from '../../service';
import { DND_ITEM_QUESTION } from './constants';

import './EditingQuestionWrapper.scss';
import './Wrapper.scss';

class EditingQuestionWrapper extends Component {
  constructor(props) {
    super(props);

    this.state = {
      question : this.props.question.getCopy(),
      errors : this.props.errors.getCopy(),
    };

    this.validationStates = {
      title : null,
    };

    let errors = this.props.errors.getCopy();
    rbValidationUtility.setValidationState('title', errors, this.validationStates, validateTitle(this.state.question.title));
  }

  componentWillReceiveProps = (props) => {
    if(!props.newType) {
      return;
    }
    let type = props.newType;
    let question = this.state.question.getCopy();
    let errors = this.state.errors.getCopy();
    if (question.type != type) {
      errors = changeQuestionError(this.state.errors, question.type, type);
      question = changeQuestionType(question, type);
    }
    question.type = type;
    this.setState({ question, errors });
  }

  handleOnTitleChange = (event) => {
    const title = event.target.value;
    const question = this.state.question.getCopy();
    question.title = title;
    let errors = this.state.errors.getCopy();
    rbValidationUtility.setValidationState('title', errors, this.validationStates, validateTitle(title));
    this.setState({ question, errors });
  }

  handleOnQuestionUpdate = (question, errors) => {
    this.setState({ question: question.getCopy(), errors : errors.getCopy() });
  }

  handleOnSaveClick = () => {
    this.props.handleOnQuestionSave(this.state.question, this.state.errors);
  }

  handleOnCancelClick = () => {
    this.props.handleOnEditingQuestionNumberChange(-1);
  }

  handleOnRequiredClick = () => {
    let { question } = this.state;
    question.isRequired = !question.isRequired;
    this.setState({ question: question.getCopy() });
  }

  handleOnDeleteClick = () => {
    this.props.handleOnDeleteClick();
  }

  render = () => {
    const opacity = this.props.isDragging ? 0 : 1;

    return this.props.connectDragPreview(
      <div style={{ opacity }} ref={node => (this.node = node)}>
        <Panel className={isQuestionValid(this.state.errors) ? 'editing-question-wrapper' : 'editing-question-wrapper panel-has-error'}>
          {this.props.connectDragSource(
            <span className="editing-question-wrapper-action__move">
              <Glyphicon glyph="move" title="Move question" /> Move
            </span>,
          )}
          <div className="top-actions">
            <Checkbox onChange={this.handleOnRequiredClick} checked={this.state.question.isRequired} className="top-actions__required">
              Required
            </Checkbox>
            <Glyphicon glyph="trash" role="button" title="Remove question" onClick={this.handleOnDeleteClick} />
          </div>
          <FormGroup validationState={this.validationStates.title}>
            <Col sm={10} smOffset={1}>
              {
                <div>
                  <ControlLabel>
                    {this.state.errors.title || 'Title'}
                  </ControlLabel>
                  <FormControl
                    name="title"
                    type="text"
                    placeholder="Enter title"
                    value={this.state.question.title}
                    onChange={this.handleOnTitleChange}
                  />
                </div>
              }
            </Col>
          </FormGroup>
          {
            questionsFactory[this.state.question.type](
              this.state.question,
              this.handleOnQuestionUpdate,
              {
                editing : true,
                errors : this.state.errors,
              },
            )
          }
          <ButtonGroup className="bottom-actions">
            <Button onClick={this.handleOnSaveClick} disabled={!isQuestionValid(this.state.errors)}>
              Save
            </Button>
            <Button onClick={this.handleOnCancelClick}>
              Cancel
            </Button>
          </ButtonGroup>
        </Panel>
      </div>,
    );
  }
}

EditingQuestionWrapper.propTypes = {
  number : PropTypes.any.isRequired,
  index : PropTypes.number.isRequired,
  question : PropTypes.instanceOf(Question).isRequired,
  newType : PropTypes.string,
  errors : PropTypes.instanceOf(QuestionError).isRequired,
  isDragging: PropTypes.bool.isRequired,
  handleOnQuestionSave : PropTypes.func.isRequired,
  handleOnEditingQuestionNumberChange : PropTypes.func.isRequired,
  handleOnDeleteClick : PropTypes.func.isRequired,
  connectDragSource: PropTypes.func.isRequired,
  connectDragPreview: PropTypes.func.isRequired,
};

const editingQuestionWrapperSourceSpec = {
  beginDrag(props) {
    return {
      number : props.id,
      index : props.index,
    };
  },
};

const editingQuestionWrapperSourceCollect = (connect, monitor) => ({
  connectDragSource : connect.dragSource(),
  connectDragPreview : connect.dragPreview(),
  isDragging : monitor.isDragging(),
});

export default DragSource(
  DND_ITEM_QUESTION,
  editingQuestionWrapperSourceSpec,
  editingQuestionWrapperSourceCollect)(EditingQuestionWrapper);
