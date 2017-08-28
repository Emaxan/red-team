import React, { Component } from 'react';
import { Panel, Col, FormGroup, FormControl } from 'react-bootstrap';
import PropTypes from 'prop-types';

// import './FileQuestion.scss';

export class FileQuestion extends Component {
  constructor(props) {
    super(props);

    let metaInfo = this.props.question.metaInfo.map(m => m);

    this.state = {
      number : this.props.question.number,
      type : this.props.question.type,
      title : this.props.question.title,
      isRequired : this.props.question.isRequired,
      metaInfo : metaInfo,
    };
  }

  handleOnTitleChange = (event) => {
    let title = event.target.value;
    this.setState({ title : title });
    let question = {...this.state};
    question.title = title;
    this.props.handleOnQuestionUpdate(question);
  }

  handleOnFileChange = (event) => {
    let file = event.target.value;
    this.setState({ metaInfo : this.fileUpload.files[0].name });
    let question = {...this.state};
    question.metaInfo = file;
    this.props.handleOnQuestionUpdate(question);
  }

  handleOnOptionChange = (optionId, value) => {
    let metaInfo = this.state.metaInfo.map(m => m);
    metaInfo[optionId] = value;
    this.setState({ metaInfo : metaInfo });
    let question = {...this.state};
    question.metaInfo = metaInfo;
    this.props.handleOnQuestionUpdate(question);
  }

  handleOnAddOption = () => {
    let metaInfo = this.state.metaInfo.map(m => m);
    metaInfo.push('');
    this.setState({ metaInfo : metaInfo });
    let question = {...this.state};
    question.metaInfo = metaInfo;
    this.props.handleOnQuestionUpdate(question);
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
            <input
              name="option"
              type="file"
              onChange={this.handleOnFileChange}
              ref={(ref) => this.fileUpload = ref}
            />
            <FormControl
              readOnly
              name="option"
              type="text"
              value={this.state.metaInfo || ''}
              placeholder="Select file"
            />
          </Col>
        </FormGroup>
      </Panel>
    );
  }
}

FileQuestion.propTypes = {
  question: PropTypes.object.isRequired,
  handleOnQuestionUpdate: PropTypes.func.isRequired,
  editing : PropTypes.bool,
};

FileQuestion.defaultProps = {
  editing : false,
};
