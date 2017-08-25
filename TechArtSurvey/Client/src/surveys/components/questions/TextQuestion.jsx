import React, { Component } from 'react';
import { Panel, Col, FormGroup, FormControl } from 'react-bootstrap';
import PropTypes from 'prop-types';

export class TextQuestion extends Component {
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

        <FormGroup>
          <Col sm={8} smOffset={1}>
            {
              this.props.editing ?
                (
                  <FormControl
                    type='text'
                    name={this.state.title}
                    value={this.state.options}
                    placeholder="Option"
                    onChange={(e) => this.handleOnOptionChange(0, e.target.value)}
                  />
                ) :
                (
                  <FormControl
                    type='text'
                    name={this.state.title}
                    placeholder={this.state.options}
                    onChange={(e) => this.handleOnOptionChange(0, e.target.value)}
                  />
                )
            }
          </Col>
        </FormGroup>
      </Panel>
    );
  }
}

TextQuestion.propTypes = {
  question: PropTypes.object.isRequired,
  handleOnQuestionChange: PropTypes.func.isRequired,
  editing : PropTypes.bool,
};

TextQuestion.defaultProps = {
  editing : false,
};
