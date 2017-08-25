import React, { Component } from 'react';
import { Panel, Col, FormGroup, FormControl, Button, Checkbox } from 'react-bootstrap';
import PropTypes from 'prop-types';

import './MultipleQuestion.scss';

export class MultipleQuestion extends Component {
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

  handleOnAddOption = () => {
    let { options } = this.state;
    options.push('');
    this.setState({ options });
  }

  render = () => {
    return (
      <Panel>
        <FormGroup>
          <Col sm={10} smOffset={1}>
            {
              this.props.editing ?
                (
                  <FormControl
                    name="title"
                    type="text"
                    value={this.state.title}
                    placeholder="Enter question's title"
                    onChange={this.handleOnTitleChange}
                  />
                ) :
                (
                  this.props.question.title
                )
            }
          </Col>
        </FormGroup>

        {
          this.state.options.map((option, i) => {
            return (
              <FormGroup key={i}>
                <Col sm={8} smOffset={1}>
                  {
                    this.props.editing ?
                      (
                        <FormControl
                          type='text'
                          name={this.state.title}
                          value={option}
                          placeholder="Option"
                          onChange={(e) => this.handleOnOptionChange(i, e.target.value)}
                        />
                      ) :
                      (
                        <Checkbox id={`${this.state.number}.${i}`} name={this.state.title}>
                          <label htmlFor={`${this.state.number}.${i}`} className="option">{option}</label>
                        </Checkbox>
                      )
                  }
                </Col>
              </FormGroup>
            );
          })
        }

        {
          this.props.editing &&
          (
            <FormGroup className="text-center">
              <Button onClick={this.handleOnAddOption}>
                Add option
              </Button>
            </FormGroup>
          )
        }
      </Panel>
    );
  }
}

MultipleQuestion.propTypes = {
  question: PropTypes.object.isRequired,
  handleOnQuestionChange: PropTypes.func.isRequired,
  editing : PropTypes.bool,
};

MultipleQuestion.defaultProps = {
  editing : false,
};
