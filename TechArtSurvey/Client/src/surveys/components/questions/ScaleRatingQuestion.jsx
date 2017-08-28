import React, { Component } from 'react';
import { Panel, Col, FormGroup, FormControl } from 'react-bootstrap';
import Nouislider from 'react-nouislider';
import 'react-nouislider/example/nouislider.css';
import 'nouislider/distribute/nouislider.css';
import PropTypes from 'prop-types';

import './ScaleRatingQuestion.scss';

export class ScaleRatingQuestion extends Component {
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
            <Nouislider
              animate={true}
              animationDuration={300}
              range={{
                min: 0,
                max: 100,
              }}
              start={[50]}
              connect={[true, false]}
              step={1}
              tooltips
              pips={{
                mode: 'steps',
                filter: function ( value ) {
                  return ((value % 5) ? 0 : 2);
                },
              }}
              ref={ref => this.slider = ref}
            />
          </Col>
        </FormGroup>
      </Panel>
    );
  }
}

ScaleRatingQuestion.propTypes = {
  question: PropTypes.object.isRequired,
  handleOnQuestionUpdate: PropTypes.func.isRequired,
  editing : PropTypes.bool,
};

ScaleRatingQuestion.defaultProps = {
  editing : false,
};
