﻿using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using JetBrains.Annotations;
using Microsoft.Owin.Security.OAuth;
using RedTeam.Logger;
using RedTeam.TechArtSurvey.DomainModel.Entities.Users;
using RedTeam.TechArtSurvey.Foundation.Dto.UsersDto;
using RedTeam.TechArtSurvey.Foundation.Identity.Managers;
using RedTeam.TechArtSurvey.Foundation.Interfaces;
using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;
using RedTeam.TechArtSurvey.Foundation.Responses;
using RedTeam.TechArtSurvey.Repositories.Interfaces;

namespace RedTeam.TechArtSurvey.Foundation.Services
{
    [UsedImplicitly]
    public class UserService : IUserService
    {
        private readonly ApplicationUserManager _userManager;
        private readonly IMapper _mapper;
        private readonly ITechArtSurveyUnitOfWork _uow;
        private readonly ApplicationRoleManager _roleManager;

        public UserService(ApplicationUserManager userManager, ApplicationRoleManager roleManager, ITechArtSurveyUnitOfWork uow, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _uow = uow;
        }


        public async Task<IServiceResponse<EditUserDto>> CreateAsync(EditUserDto userDto)
        {
            var us = _mapper.Map<EditUserDto, User>(userDto);
            us.Role = await _roleManager.FindByNameAsync(default(RoleTypes).ToString());
            var result = await _userManager.CreateAsync(us, us.Password);
            return !result.Succeeded ? 
                ServiceResponse.CreateUnsuccessful<EditUserDto>(ServiceResponseCode.UserAlreadyExists) : 
                ServiceResponse.CreateSuccessful(_mapper.Map<User, EditUserDto>(us));
        }

        public async Task<IServiceResponse<ClaimsIdentity>> GetClaimsByCredentialsAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var isPasswordValid = await _userManager.CheckPasswordAsync(user, password);
            if (user == null || !isPasswordValid)
            {
                return ServiceResponse.CreateUnsuccessful<ClaimsIdentity>(ServiceResponseCode.InvalidCredentials);
            }
            var claims = await _userManager.GetClaimsAsync(user.Id);
            var claimsIdentity = new ClaimsIdentity(OAuthDefaults.AuthenticationType);
            claimsIdentity.AddClaims(claims);

            return ServiceResponse.CreateSuccessful(claimsIdentity);
        }

        public async Task<IServiceResponse> UpdateAsync(EditUserDto user)
        {
            LoggerContext.Logger.Info($"Update user with email = {user.Email}");

            var us = await _userManager.FindByIdAsync(user.Id);
            if (us == null)
            {
                return ServiceResponse.CreateUnsuccessful<object>(ServiceResponseCode.UserNotFoundById);
            }
            await _userManager.UpdateAsync(_mapper.Map(user, us));

            return ServiceResponse.CreateSuccessful();
        }

        public async Task<IServiceResponse> DeleteByIdAsync(int id)
        {
            LoggerContext.Logger.Info($"Delete user with id = {id}");

            var us = await _uow.Users.GetByIdAsync(id, u => u.Role);
            if (us == null)
            {
                return ServiceResponse.CreateUnsuccessful<object>(ServiceResponseCode.UserNotFoundById);
            }
            _uow.Users.Delete(us);

            return ServiceResponse.CreateSuccessful();
        }

        public async Task<IServiceResponse<ReadUserDto>> GetByIdAsync(int id)
        {
            LoggerContext.Logger.Info($"Get user with id = {id}");

            var user = await _uow.Users.GetByIdAsync(id, u => u.Role);
            return user == null ? 
                ServiceResponse.CreateUnsuccessful<ReadUserDto>(ServiceResponseCode.UserNotFoundById) : 
                ServiceResponse.CreateSuccessful(_mapper.Map<User, ReadUserDto>(user));
        }

        public async Task<IServiceResponse<ReadUserDto>> GetByEmailAsync(string email)
        {
            LoggerContext.Logger.Info($"Get user by email = {email}");

            var user = await _uow.Users.GetUserByEmailAsync(email, u => u.Role);
            return user == null
                       ? ServiceResponse.CreateUnsuccessful<ReadUserDto>(ServiceResponseCode.UserNotFoundByEmail)
                       : ServiceResponse.CreateSuccessful(_mapper.Map<User, ReadUserDto>(user));
        }

        public async Task<IServiceResponse<bool>> CheckByEmailAsync(string email)
        {
            LoggerContext.Logger.Info($"Get user with email = {email}");

            var user = await _uow.Users.GetUserByEmailAsync(email, u => u.Role);
            return user == null ? 
                ServiceResponse.CreateSuccessful(false) : 
                ServiceResponse.CreateSuccessful(true);
        }

        public async Task<IServiceResponse<IReadOnlyCollection<ReadUserDto>>> GetAllAsync()
        {
            LoggerContext.Logger.Info("Get all users");

            var users = await _uow.Users.GetAllAsync(u => u.Role);
            var mapped = _mapper.Map<IReadOnlyCollection<User>, IReadOnlyCollection<ReadUserDto>>(users);

            return ServiceResponse.CreateSuccessful(mapped);
        }
    }
}