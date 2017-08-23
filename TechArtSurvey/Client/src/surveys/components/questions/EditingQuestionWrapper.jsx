import React, { Component } from 'react';
import { Panel, Button } from 'react-bootstrap';
import PropTypes from 'prop-types';

import { questionsFactory } from '../questionsFactory';

export class EditingQuestionWrapper extends Component {
  render = () =>
    <Panel>
      {
        questionsFactory[this.props.question.type](
          this.props.question,
          this.props.handleOnQuestionChange,
        )
      }
      <Button>
            Save
      </Button>
    </Panel>
}

EditingQuestionWrapper.propTypes = {
  handleOnQuestionChange: PropTypes.func.isRequired,
  question: PropTypes.object.isRequired,
};