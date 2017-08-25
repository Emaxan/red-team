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

@DropTarget(ItemTypes.QUESTION, questionTarget, connect => ({
  connectDropTarget: connect.dropTarget(),
}))
@DragSource(ItemTypes.QUESTION, questionSource, (connect, monitor) => ({
  connectDragSource: connect.dragSource(),
  isDragging: monitor.isDragging(),
}))
export default class DraggableQuestion extends Component {
  static propTypes = {
    connectDragSource: PropTypes.func.isRequired,
    connectDropTarget: PropTypes.func.isRequired,
    index: PropTypes.number.isRequired,
    isDragging: PropTypes.bool.isRequired,
    id: PropTypes.any.isRequired,
    moveQuestion: PropTypes.func.isRequired,
    children : PropTypes.any.isRequired,
  };

  render() {
    const { children, isDragging, connectDragSource, connectDropTarget } = this.props;
    const opacity = isDragging ? 0.5 : 1;

    return connectDragSource(connectDropTarget(
      <div style={{ opacity }} ref={node => (this.node = node)}>
        {children}
      </div>,
    ));
  }
}
