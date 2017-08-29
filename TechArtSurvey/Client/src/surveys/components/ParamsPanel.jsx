import React, { Component } from 'react';
import { Panel, ButtonToolbar, ToggleButton, ToggleButtonGroup } from 'react-bootstrap';
import PropTypes from 'prop-types';

export class ParamsPanel extends Component {
  constructor(props) {
    super(props);
    this.state = {
      settings : {...this.props.settings},
    };
  }

  componentWillReceiveProps = (props) => {
    this.setState({ settings : {...props.settings} });
  }

  handleOnIsAnonymousChange = () => {
    let settings = {...this.state.settings};
    settings.isAnonymous = !settings.isAnonymous;
    this.setState({ settings : settings });
    this.props.handleOnSettingsChange(settings);
  }

  handleOnHasQuestionNumbersChange = () => {
    let settings = {...this.state.settings};
    settings.hasQuestionNumbers = !settings.hasQuestionNumbers;
    this.setState({ settings : settings });
    this.props.handleOnSettingsChange(settings);
  }

  handleOnHasPageNumbersChange = () => {
    let settings = {...this.state.settings};
    settings.hasPageNumbers = !settings.hasPageNumbers;
    this.setState({ settings : settings });
    this.props.handleOnSettingsChange(settings);
  }

  handleOnIsRandomOrderedChange = () => {
    let settings = {...this.state.settings};
    settings.isRandomOrdered = !settings.isRandomOrdered;
    this.setState({ settings : settings });
    this.props.handleOnSettingsChange(settings);
  }

  handleOnHasRequiredFieldsStarsChange = () => {
    let settings = {...this.state.settings};
    settings.hasRequiredFieldsStars = !settings.hasRequiredFieldsStars;
    this.setState({ settings : settings });
    this.props.handleOnSettingsChange(settings);
  }

  handleOnHasProgressIndicatorChange = () => {
    let settings = {...this.state.settings};
    settings.hasProgressIndicator = !settings.hasProgressIndicator;
    this.setState({ settings : settings });
    this.props.handleOnSettingsChange(settings);
  }

  render = () => {
    return (
      <Panel header="Survey params" bsStyle="primary">
        <ButtonToolbar>
          <ToggleButtonGroup type="checkbox" vertical>
            <ToggleButton value={1} checked={this.state.settings.isAnonymous} onClick={this.handleOnIsAnonymousChange}>
                Anonymous
            </ToggleButton>
            <ToggleButton value={2} checked={this.state.settings.hasQuestionNumbers} onClick={this.handleOnHasQuestionNumbersChange}>
                Question numbers
            </ToggleButton>
            <ToggleButton value={3} checked={this.state.settings.hasPageNumbers} onClick={this.handleOnHasPageNumbersChange}>
                Page numbers
            </ToggleButton>
            <ToggleButton value={4} checked={this.state.settings.isRandomOrdered} onClick={this.handleOnIsRandomOrderedChange}>
                Random order of questions
            </ToggleButton>
            <ToggleButton value={5} checked={this.state.settings.hasRequiredFieldsStars} onClick={this.handleOnHasRequiredFieldsStarsChange}>
                Stars for required fields
            </ToggleButton>
            <ToggleButton value={6} checked={this.state.settings.hasProgressIndicator} onClick={this.handleOnHasProgressIndicatorChange}>
                Progress indicator
            </ToggleButton>
          </ToggleButtonGroup>
        </ButtonToolbar>
      </Panel >
    );
  }
}

ParamsPanel.propTypes = {
  handleOnSettingsChange : PropTypes.func.isRequired,
  settings : PropTypes.object.isRequired,
};
