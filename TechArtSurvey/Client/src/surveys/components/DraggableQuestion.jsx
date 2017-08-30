import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { DragSource, DropTarget  } from 'react-dnd';

import { ItemTypes } from './constants';

const questionSource = {
  beginDrag(props) {
    return {
      id : props.id,
      index : props.index,
    };
  },
};

const questionTarget = {
  hover(props, monitor, component) {
    const dragIndex = monitor.getItem().index;
    const hoverIndex = props.index;

    if (dragIndex === hoverIndex) {
      return;
    }

    const hoverBoundingRect = component.decoratedComponentInstance.node.getBoundingClientRect();
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

class DraggableQuestion extends Component {
  render() {
    const opacity = this.props.isDragging ? 0.5 : 1;

    return (
      this.props.connectDragSource(this.props.connectDropTarget(
        <div style={{ opacity }} ref={node => (this.node = node)}>
          {this.props.children}
        </div>,
      ))
    );
  }
}

DraggableQuestion.propTypes = {
  connectDragSource : PropTypes.func.isRequired,
  connectDropTarget : PropTypes.func.isRequired,
  isDragging : PropTypes.bool.isRequired,
  id : PropTypes.any.isRequired,
  index : PropTypes.number.isRequired,
  moveQuestion : PropTypes.func.isRequired,
  children : PropTypes.any.isRequired,
};

const dropTargetCollect = (connect) => ({
  connectDropTarget : connect.dropTarget(),
});

const dragSourceCollect = (connect, monitor) => ({
  connectDragSource : connect.dragSource(),
  isDragging : monitor.isDragging(),
});

export default DropTarget(ItemTypes.QUESTION, questionTarget, dropTargetCollect)(
  DragSource(ItemTypes.QUESTION, questionSource, dragSourceCollect)(
    DraggableQuestion),
);