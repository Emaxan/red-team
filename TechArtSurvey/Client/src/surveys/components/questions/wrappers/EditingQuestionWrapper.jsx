import React, { Component } from 'react';
import { Panel, Button, Checkbox, ButtonGroup, Glyphicon, ControlLabel, FormControl, FormGroup, Col } from 'react-bootstrap';
import PropTypes from 'prop-types';
import { DragSource } from 'react-dnd';

import { questionsFactory } from '../../questionsFactory';
import Question from '../../../models/Question';
import QuestionError from '../../../models/QuestionError';
import { validateTitle } from '../../../../utils/validation/questionValidation';
import { reactBootstrapValidationUtility as rbValidationUtility } from '../../../../utils/validation/reactBootstrapValidationUtility';
import { isQuestionValid } from '../../service';
import { ItemTypes } from '../dnd/constants';

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
    let { type } = props.question;
    let question = this.state.question.getCopy();
    question.type = type;
    this.setState({ question });
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
    const { isDragging, connectDragSource, connectDragPreview } = this.props;
    const opacity = isDragging ? 0.4 : 1;

    return connectDragPreview(
      <div style={ { opacity } } ref={node => (this.node = node)}>
        <Panel className={isQuestionValid(this.state.errors) ? 'editing-question-wrapper' : 'editing-question-wrapper panel-has-error'}>
          {connectDragSource(
            <span className="test-class">
              <Glyphicon glyph="move" role="button" title="Move question" /> MOVE
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
                editing : this.props.editing,
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
  id : PropTypes.any.isRequired,
  index : PropTypes.number.isRequired,
  moveQuestion : PropTypes.func.isRequired,
  handleOnQuestionSave : PropTypes.func.isRequired,
  question : PropTypes.instanceOf(Question).isRequired,
  errors : PropTypes.instanceOf(QuestionError).isRequired,
  handleOnEditingQuestionNumberChange : PropTypes.func.isRequired,
  handleOnDeleteClick : PropTypes.func.isRequired,
  editing : PropTypes.bool.isRequired,
  connectDragSource: PropTypes.func.isRequired,
  connectDragPreview: PropTypes.func.isRequired,
  isDragging: PropTypes.bool.isRequired,
};

const editingQuestionWrapperSourceSpec = {
  canDrag() {
    return true;
  },

  beginDrag(props) {
    return {
      id : props.id,
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
  ItemTypes.QUESTION,
  editingQuestionWrapperSourceSpec,
  editingQuestionWrapperSourceCollect)(EditingQuestionWrapper);
