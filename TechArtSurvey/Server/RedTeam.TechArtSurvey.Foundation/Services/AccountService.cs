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
using Microsoft.AspNet.Identity;

namespace RedTeam.TechArtSurvey.Foundation.Services
{
    [UsedImplicitly]
    public class AccountService : IAccountService
    {
        private readonly ITechArtSurveyUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly PasswordHasher _passwordHasher = new PasswordHasher();

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
                user.Password = _passwordHasher.HashPassword(user.Password);
                _uow.Users.Create(_mapper.Map<UserDto, User>(user));
                await _uow.SaveAsync();

                serviceResponse.Code = ServiceResponseCodes.Ok;
            }

            return serviceResponse;
        }

        public async Task<IServiceResponse> GetUserByCredentialsAsync(string email, string password)
        {
            LoggerContext.Logger.Info($"Get user with email = {email}");

            ServiceResponse serviceResponse = new ServiceResponse();
            var user = await _uow.Users.GetUserByEmailAsync(email);
            if (user == null)
            {
                serviceResponse.Code = ServiceResponseCodes.NotFoundUserByEmail;
            }
            else if (_passwordHasher.VerifyHashedPassword(user.Password, password) == PasswordVerificationResult.Failed)
            {
                serviceResponse.Code = ServiceResponseCodes.InvalidPassword;
            }
            else
            {
                serviceResponse.Code = ServiceResponseCodes.Ok;
                serviceResponse.Content = _mapper.Map<User, EditUserDto>(user);                
            }
            return serviceResponse;
        }
        
        

        public async Task<IServiceResponse> LogOut(HttpContext context)
        {
         
            ServiceResponse serviceResponse = new ServiceResponse();
            serviceResponse.Code = ServiceResponseCodes.Ok;
            return serviceResponse;
        }

      
    }
}