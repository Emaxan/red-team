import React from 'react';
import { connect } from 'react-redux';

import { signUpRequest, checkEmailExistenceRequest } from './actions';
import { SignUpForm } from './components/SignUpForm';
import { AuthPanel } from '../AuthPanel';

const mapStateToProps = (state) => ({
  questionTypes : state.createSurvey.params.questionTypes,
  surveyParams: state.createSurvey.params.surveyParams,
});

const mapDispatchToProps = {
  createSurveyRequest,
  createTemplateRequest,
  getParams
};

class NewSurveyContainer extends Component {
  componentDidMount() {
    this.props.getParams();
  }

  render() {
    return <SurveyEditPanel
      questionTypes={this.props.questionTypes}
      surveyParams={this.props.surveyParams}
      createSurvey ={this.props.createSurveyRequest}
      createTemplate={this.props.createTemplateRequest}
      />
  }
}


export default connect(mapStateToProps, mapDispatchToProps)(NewSurveyContainer);
