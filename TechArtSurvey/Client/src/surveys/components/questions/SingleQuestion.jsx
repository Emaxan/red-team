import React, { Component } from 'react';
import { Panel, Col, FormGroup, FormControl, Button, Radio } from 'react-bootstrap';
import PropTypes from 'prop-types';

import './SingleQuestion.scss';

export class SingleQuestion extends Component {
  constructor(props) {
    super(props);

    let metaInfo = this.props.question.metaInfo.map(m => m);

    this.state = {
      id : this.props.question.id,
      type : this.props.question.type,
      title : this.props.question.title,
      isRequired : this.props.question.isRequired,
      metaInfo : metaInfo,
      number : this.props.question.number,
    };
  }

  handleOnTitleChange = (event) => {
    this.setState({ title : event.target.value });
    this.props.handleOnQuestionUpdate(this.state);
  }

  handleOnOptionChange = (optionId, value) => {
    let metaInfo = this.state.metaInfo.map(m => m);
    metaInfo[optionId] = value;
    this.setState({ metaInfo : metaInfo });
    this.props.handleOnQuestionUpdate(this.state);
  }

  handleOnAddOption = () => {
    let metaInfo = this.state.metaInfo.map(m => m);
    metaInfo.push('');
    this.setState({ metaInfo : metaInfo });
    this.props.handleOnQuestionUpdate(this.state);
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
          this.state.metaInfo.map((option, i) => {
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
                        <Radio id={`${this.state.number}.${i}`} name={this.state.title}>
                          <label htmlFor={`${this.state.number}.${i}`} className="option">{option}</label>
                        </Radio>
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

SingleQuestion.propTypes = {
  question: PropTypes.object.isRequired,
  handleOnQuestionUpdate: PropTypes.func.isRequired,
  editing : PropTypes.bool,
};

SingleQuestion.defaultProps = {
  editing : false,
};
