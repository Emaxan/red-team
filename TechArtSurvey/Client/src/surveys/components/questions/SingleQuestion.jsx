import React, { Component } from 'react';
import { Panel, Col, FormGroup, FormControl, Button } from 'react-bootstrap';
import PropTypes from 'prop-types';

export class SingleQuestion extends Component {
  constructor(props) {
    super(props);

    this.state = {
      id : this.props.question.id,
      type : this.props.question.type,
      title : this.props.question.title,
      isRequired : this.props.question.isRequired,
      options : this.props.question.metaInfo,
      number : this.props.question.number,
    };
  }

  handleOnTitleChange = (event) => {
    this.setState({ title : event.target.value });
  }

  handleOnOptionChange = (optionId, value) => {
    let { options } = this.state;
    options[optionId] = value;
    this.setState({ options });
  }

  handleOnEdit = () => {
    this.props.onEditingQuestionChange(this.props.question.id);
  }

  handleOnAddOption = () => {
    let { options } = this.state;
    options.push('');
    this.setState({ options });
  }

  render = () => {
    return (
      <Panel>
        <FormGroup>
          <Col sm={10}>
            <FormControl
              name="title"
              type="text"
              value={this.state.title}
              placeholder="Enter question's title"
              onChange={this.handleOnTitleChange}
            />
          </Col>
        </FormGroup>

        {
          this.state.options.map((option, i) => {
            return (
              <FormGroup key={i}>
                <FormControl
                  type="text"
                  value={option}
                  placeholder="Option"
                  onChange={(e) => this.handleOnOptionChange(i, e.target.value)}
                />
              </FormGroup>
            );
          })
        }

        <FormGroup className="text-center">
          <Button onClick={this.handleOnAddOption}>
            Add option
          </Button>
        </FormGroup>
      </Panel>
    );
  }
}

SingleQuestion.propTypes = {
  question: PropTypes.object.isRequired,
  handleOnQuestionChange: PropTypes.func.isRequired,
  onEditingQuestionChange: PropTypes.func.isRequired,
};
