﻿using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using JetBrains.Annotations;

using RedTeam.Logger;
using RedTeam.TechArtSurvey.DomainModel.Entities;
using RedTeam.TechArtSurvey.Foundation.DTO;
using RedTeam.TechArtSurvey.Foundation.Interfaces;
using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;
using RedTeam.TechArtSurvey.Repositories.Interfaces;

namespace RedTeam.TechArtSurvey.Foundation.Services
{
    [UsedImplicitly]
    public class UserService : IUserService
    {
        private readonly ITechArtSurveyUnitOfWork _uow;
        private readonly IMapper _mapper;


        public UserService(ITechArtSurveyUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }


        public async Task<IServiceResponse> CreateAsync(UserDto user)
        {
            LoggerContext.GetLogger.Info($"Create user with email = {user.Email}");

            ServiceResponse serviceResponse = new ServiceResponse();
            var us = await _uow.Users.CheckUserByEmailAsync(user.Email);
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

        public async Task<IServiceResponse> UpdateAsync(UserDto user)
        {
            LoggerContext.GetLogger.Info($"Update user with email = {user.Email}");

            ServiceResponse serviceResponse = new ServiceResponse();
            var us = await _uow.Users.CheckUserByEmailAsync(user.Email);
            if (us == null)
            {
                serviceResponse.Code = ServiceResponseCodes.NotFoundUserByEmail;
            }
            else
            {
                _uow.Users.Update(_mapper.Map<UserDto, User>(user));
                await _uow.SaveAsync();

                serviceResponse.Code = ServiceResponseCodes.Ok;
            }

            return serviceResponse;
        }

        public async Task<IServiceResponse> DeleteAsync(UserDto user)
        {
            LoggerContext.GetLogger.Info($"Delete user with email = {user.Email}");

            ServiceResponse serviceResponse = new ServiceResponse();
            var us = await _uow.Users.CheckUserByEmailAsync(user.Email);
            if (us == null)
            {
                serviceResponse.Code = ServiceResponseCodes.NotFoundUserByEmail;
            }
            else
            {
                _uow.Users.Delete(us);
                await _uow.SaveAsync();

                serviceResponse.Code = ServiceResponseCodes.Ok;
            }

            return serviceResponse;
        }

        public async Task<IServiceResponse> GetByIdAsync(int id)
        {
            LoggerContext.GetLogger.Info($"Get user with id = {id}");

            ServiceResponse serviceResponse = new ServiceResponse();
            var user = await _uow.Users.GetAsync(id);
            if (user == null)
            {
                serviceResponse.Code = ServiceResponseCodes.NotFoundUserById;
            }
            else
            {
                serviceResponse.Code = ServiceResponseCodes.Ok;
                serviceResponse.Content = _mapper.Map<User, UserDto>(user);
            }

            return serviceResponse;
        }

        public async Task<IServiceResponse> GetByEmailAsync(string email)
        {
            LoggerContext.GetLogger.Info($"Get user with email = {email}");

            ServiceResponse serviceResponse = new ServiceResponse();
            var user = await _uow.Users.GetUserByEmailAsync(email);
            if (user == null)
            {
                serviceResponse.Code = ServiceResponseCodes.NotFoundUserByEmail;
            }
            else
            {
                serviceResponse.Code = ServiceResponseCodes.Ok;
                serviceResponse.Content = _mapper.Map<User, UserDto>(user);
            }

            return serviceResponse;
        }

        public async Task<IServiceResponse> GetAllAsync()
        {
            LoggerContext.GetLogger.Info("Get all users");

            var users = await _uow.Users.GetAllAsync();
            ServiceResponse serviceResponse = new ServiceResponse()
            {
                Code = ServiceResponseCodes.Ok,
                Content = _mapper.Map<IReadOnlyCollection<User>, IReadOnlyCollection<UserDto>>(users)
            };

            return serviceResponse;
        }
    }
}