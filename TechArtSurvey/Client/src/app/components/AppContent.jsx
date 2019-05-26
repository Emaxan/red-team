import React from 'react';
import CustomScroll from 'react-custom-scroll';
import { Switch, Route } from 'react-router-dom';
import PropTypes from 'prop-types';

import Routes from '../routes';
import UserListContainer from '../../users/UserListContainer';
import SignUpContainer from '../../auth/signUp/SignUpContainer';
import LoginContainer from '../../auth/login/LoginContainer';
import ResetPasswordContainer from '../../auth/resetPassword/ResetPasswordContainer';
import ForgotPasswordContainer from '../../auth/forgotPassword/ForgotPasswordContainer';
import { AboutContainer } from '../../about/AboutContainer';
import { NotFound } from '../../error/NotFound';
import { Forbidden } from '../../error/Forbidden';
import { Home } from '../../home/Home';
import SurveyEditor from '../../survey/surveyEditor/SurveyEditor';
import SurveyListContainer from '../../survey/surveyList/SurveyListContainer';
import SurveyContainer from '../../survey/passSurvey/SurveyContainer';
import {
  userIsAuthenticatedRedirect,
  userIsNotAuthenticatedRedirect,
  userIsAdminRedirect,
} from '../../auth/authWrappers';

import './AppContent.scss';
import './customScroll.scss';

const UserList = userIsAuthenticatedRedirect(userIsAdminRedirect(UserListContainer));
const Login = userIsNotAuthenticatedRedirect(LoginContainer);
const SignUp = userIsNotAuthenticatedRedirect(SignUpContainer);
const ForgotPassword = userIsNotAuthenticatedRedirect(ForgotPasswordContainer);
const ResetPassword = userIsNotAuthenticatedRedirect(ResetPasswordContainer);
const EditSurvey = userIsAuthenticatedRedirect(userIsAdminRedirect(SurveyEditor));
const SurveyList = userIsAuthenticatedRedirect(SurveyListContainer);
const PassSurvey = userIsAuthenticatedRedirect(SurveyContainer);

const AppContent = ({ className }) => (
  <div className={'main ' + className}>
    <CustomScroll flex="1">
      <Switch>
        <Route path={Routes.Forbidden.path} component={Forbidden} />
        <Route exact path={Routes.Main.path} component={Home}/>
        <Route path={Routes.Users.path} component={UserList} />
        <Route path={Routes.SignUp.path} component={SignUp}/>
        <Route path={Routes.Login.path} component={Login} />
        <Route path={Routes.About.path} component={AboutContainer} />
        <Route path={Routes.ForgotPassword.path} component={ForgotPassword} />
        <Route path={Routes.ResetPassword.path.concat(Routes.ResetPassword.params)} component={ResetPassword} />
        <Route path={Routes.EditSurvey.path.concat(Routes.EditSurvey.params)} component={EditSurvey} />
        <Route exact path={Routes.Surveys.path} component={SurveyList} />
        <Route exact path={Routes.PassSurvey.path.concat(Routes.PassSurvey.params)} component={PassSurvey} />
        <Route component={NotFound} />
      </Switch>
    </CustomScroll>
  </div>
);

AppContent.propTypes = {
  className : PropTypes.string,
};

export default AppContent;
