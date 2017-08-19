﻿using AutoMapper;
using JetBrains.Annotations;
using RedTeam.Identity.Managers;
using RedTeam.Identity.Responses;
using RedTeam.Logger;
using RedTeam.TechArtSurvey.DomainModel.Entities;
using RedTeam.TechArtSurvey.Foundation.Dto.UsersDto;
using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using RedTeam.TechArtSurvey.Foundation.Interfaces;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;

namespace RedTeam.Identity
{
    [UsedImplicitly]
    public class UserService : IUserService
    {
        private readonly ApplicationUserManager _userManager;
        private readonly IMapper _mapper;

        public UserService(ApplicationUserManager manager, IMapper mapper)
        {
            _userManager = manager;
            _mapper = mapper;
        }


        public async Task<IServiceResponse> CreateAsync(UserDto userDto)
        {
            var us = _mapper.Map<UserDto, User>(userDto);
            await _userManager.CreateAsync(us, us.Password);
            await _userManager.AddToRoleAsync(us.Id, default(RoleTypes).ToString());

            return ServiceResponse.CreateSuccessful(us);
        }

        public async Task<IServiceResponse> GetClaimsByCredentialsAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return ServiceResponse.CreateUnsuccessful(ServiceResponseCodes.UserNotFoundByEmail);
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
                return ServiceResponse.CreateUnsuccessful(ServiceResponseCodes.UserNotFoundById);
            }
            await _userManager.UpdateAsync(_mapper.Map(user, us));

            return ServiceResponse.CreateSuccessful(null);
        }

        public async Task<IServiceResponse> DeleteByIdAsync(int id)
        {
            LoggerContext.Logger.Info($"Delete user with id = {id}");

            var us = await _userManager.FindByIdAsync(id);
            if (us == null)
            {
                return ServiceResponse.CreateUnsuccessful(ServiceResponseCodes.UserNotFoundById);
            }
            await _userManager.DeleteAsync(us);

            return ServiceResponse.CreateSuccessful(null);
        }

        public async Task<IServiceResponse> GetByIdAsync(int id)
        {
            LoggerContext.Logger.Info($"Get user with id = {id}");

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return ServiceResponse.CreateUnsuccessful(ServiceResponseCodes.UserNotFoundById);
            }

            return ServiceResponse.CreateSuccessful(_mapper.Map<User, EditUserDto>(user));
        }

        public async Task<IServiceResponse> CheckByEmailAsync(string email)
        {
            LoggerContext.Logger.Info($"Get user with email = {email}");

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return ServiceResponse.CreateSuccessful(null);
            }

            return ServiceResponse.CreateUnsuccessful(ServiceResponseCodes.UserAlreadyExists);
        }

        public async Task<IServiceResponse> GetAllAsync()
        {
            LoggerContext.Logger.Info("Get all users");

            var users = await _userManager.GetAllAsync();
            var mapped = _mapper.Map<IReadOnlyCollection<User>, IReadOnlyCollection<EditUserDto>>(users);

            return ServiceResponse.CreateSuccessful(mapped);
        }
    }
}
