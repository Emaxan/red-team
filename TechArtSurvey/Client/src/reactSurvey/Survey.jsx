import React, { Component } from 'react';
import { connect } from 'react-redux';
//import * as Survey from 'survey-react';
import SurveyEditor from './SurveyEditor';


import 'survey-react/survey.css';

// const mapStateToProps = (state) => ({
//   errors : state.surveys.errors,
//   survey : new Survey(),
// });

// const mapDispatchToProps = {
//   saveSurvey : createSurveyRequest,
//   cancelSurveyCreation : cancelSurveyCreationRequest,
// };

class reactSurvey extends Component {
  render() {
    return (
      <div className="editorContainer">
        <SurveyEditor />
      </div>
    );
  }
}

reactSurvey.propTypes = {

};

export default connect()(reactSurvey);
