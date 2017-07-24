using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using JetBrains.Annotations;

using RedTeam.Logger;
using RedTeam.TechArtSurvey.DomainModel.Entities;
using RedTeam.TechArtSurvey.Foundation.Dto.UsersDto;
using RedTeam.TechArtSurvey.Foundation.Dto.AccountDto;
using RedTeam.TechArtSurvey.Foundation.Interfaces;
using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;
using RedTeam.TechArtSurvey.Repositories.Interfaces;
using System.Web.Security;
using System.Web;
using System;

namespace RedTeam.TechArtSurvey.Foundation.Services
{
    [UsedImplicitly]
    public class AccountService : IAccountService
    {
        private readonly ITechArtSurveyUnitOfWork _uow;
        private readonly IMapper _mapper;
        private const string _authCookieName = "AUTHENTICATION";


        public AccountService(ITechArtSurveyUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IServiceResponse> SingupAsync(UserDto user)
        {
            LoggerContext.Logger.Info($"Create user with email = {user.Email}");

            ServiceResponse serviceResponse = new ServiceResponse();
            var us = await _uow.Users.GetUserByEmailAsync(user.Email);
            if (us != null)
            {
                serviceResponse.Code = ServiceResponseCodes.UserAlreadyExists;
            }
            else
            {
                _uow.Users.Create(_mapper.Map<UserDto, User>(user));
                await _uow.SaveAsync();

                serviceResponse.Code = ServiceResponseCodes.Ok;
            }

            return serviceResponse;
        }

        public async Task<IServiceResponse> LoginAsync(LoginDto loginDto, HttpContext context)
        {
            LoggerContext.Logger.Info($"Get user with email = {loginDto.Email}");

            ServiceResponse serviceResponse = new ServiceResponse();
            var user = await _uow.Users.GetUserByEmailAsync(loginDto.Email);
            if (user == null)
            {
                serviceResponse.Code = ServiceResponseCodes.NotFoundUserByEmail;
            }
            else
            {
                serviceResponse.Code = ServiceResponseCodes.Ok;
                serviceResponse.Content = _mapper.Map<User, EditUserDto>(user);
                var cookie = CreateCookie(user.Email);
                context.Response.Cookies.Set(cookie);
            }
            return serviceResponse;
        }

        public async Task<IServiceResponse> LogOut(HttpContext context)
        {
            var httpCookie = context.Response.Cookies[_authCookieName];
            ServiceResponse serviceResponse = new ServiceResponse();
            if (httpCookie != null)
            {
                httpCookie.Expires = DateTime.Now.AddDays(-1d);
                serviceResponse.Code = ServiceResponseCodes.Ok;
                serviceResponse.Content = "User was logged out";
            }
            else
            {
                serviceResponse.Code = ServiceResponseCodes.NotFoundUserByEmail;
                serviceResponse.Content = "Auth cookie was not found";
            }
            return serviceResponse;
        }

        private HttpCookie CreateCookie(string userName, bool isPersistent = false)
        {
            var ticket = new FormsAuthenticationTicket(
                  1,
                  userName,
                  DateTime.Now,
                  DateTime.Now.Add(FormsAuthentication.Timeout),
                  isPersistent,
                  string.Empty,
                  FormsAuthentication.FormsCookiePath);

            // Encrypt the ticket.
            var encTicket = FormsAuthentication.Encrypt(ticket);

            // Create the cookie.
            var cookie = new HttpCookie(_authCookieName)
            {
                Value = encTicket,
                Expires = DateTime.Now.Add(FormsAuthentication.Timeout)
            };
            cookie["token"] = "here must be a token";
            return cookie;
        }
    }
}