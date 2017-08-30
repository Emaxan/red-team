import React, { Component } from 'react';
import { Panel, Col, FormGroup, FormControl } from 'react-bootstrap';
import PropTypes from 'prop-types';

export class StarRatingQuestion extends Component {
  constructor(props) {
    super(props);

    let metaInfo = this.props.question.metaInfo.map(m => m);

    if(metaInfo.length < 1) {
      metaInfo.push(0);
    }

    this.state = {
      number : this.props.question.number,
      type : this.props.question.type,
      title : this.props.question.title,
      isRequired : this.props.question.isRequired,
      metaInfo : metaInfo,
    };
  }

  componentWillReceiveProps = (props) => {
    let metaInfo = props.question.metaInfo.map(m => m);
    this.setState({
      number : props.question.number,
      type : props.question.type,
      title : props.question.title,
      isRequired : props.question.isRequired,
      metaInfo : metaInfo,
    });
  }

  handleOnTitleChange = (event) => {
    let title = event.target.value;
    this.setState({ title : title });
    let question = {...this.state};
    question.title = title;
    this.props.handleOnQuestionUpdate(question);
  }

  handleOnClick = (number) => {
    this.setState({ matainfo : [number] });
    let question = {...this.state};
    question.metaInfo = [number];
    this.props.handleOnQuestionUpdate(question);
  }

  render = () => {

    let i = 0;
    let stars = [];
    while(i < this.state.metaInfo[0]) {
      stars.push('glyphicon glyphicon-star');
      i++;
    }

    while(i < (5 - this.state.metaInfo[0])) {
      stars.push('glyphicon glyphicon-star-empty');
      i++;
    }

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
              stars.map((star, i) => (<span key={i} className={star} onClick={this.handleOnClick.bind(this, i+1)}/>))
            }
          </Col>
        </FormGroup>
      </Panel>
    );
  }
}

StarRatingQuestion.propTypes = {
  question: PropTypes.object.isRequired,
  handleOnQuestionUpdate: PropTypes.func.isRequired,
  editing : PropTypes.bool,
};

StarRatingQuestion.defaultProps = {
  editing : false,
};
