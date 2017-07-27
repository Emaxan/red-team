using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using JetBrains.Annotations;

using RedTeam.Logger;
using RedTeam.TechArtSurvey.DomainModel.Entities;
using RedTeam.TechArtSurvey.Foundation.Dto.UsersDto;
using RedTeam.TechArtSurvey.Foundation.Interfaces;
using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;
using RedTeam.TechArtSurvey.Repositories.Interfaces;
using Microsoft.AspNet.Identity;

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

        public async Task<IServiceResponse> CreateAsync(UserDto userDto)
        {
            User user = await _uow.UserManager.FindByEmailAsync(userDto.Email);
            ServiceResponse serviceResponse = new ServiceResponse();
            if (user == null)
            {
                await _uow.UserManager.CreateAsync(_mapper.Map<UserDto, User>(userDto));
                // добавляем роль
                //await _uow.UserManager.AddToRoleAsync(user.Id, userDto.Role);
                await _uow.SaveAsync();
                serviceResponse.Code = ServiceResponseCodes.Ok;
                return serviceResponse;

            }
            else
            {
                serviceResponse.Code = ServiceResponseCodes.UserAlreadyExists;
                return serviceResponse;
            }
        }

        //public async Task<IServiceResponse> CreateAsync(UserDto user)
        //{
        //    LoggerContext.Logger.Info($"Create user with email = {user.Email}");

        //    ServiceResponse serviceResponse = new ServiceResponse();
        //    var us = await _uow.Users.GetUserByEmailAsync(user.Email);
        //    if (us != null)
        //    {
        //        serviceResponse.Code = ServiceResponseCodes.UserAlreadyExists;
        //    }
        //    else
        //    {
        //        user.Password = _passwordHasher.HashPassword(user.Password);
        //        _uow.Users.Create(_mapper.Map<UserDto, User>(user));
        //        await _uow.SaveAsync();

        //        serviceResponse.Code = ServiceResponseCodes.Ok;
        //    }

        //    return serviceResponse;
        //}

        public async Task<IServiceResponse> UpdateAsync(EditUserDto user)
        {
            LoggerContext.Logger.Info($"Update user with email = {user.Email}");

            ServiceResponse serviceResponse = new ServiceResponse();
            var us = await _uow.UserManager.FindByIdAsync(user.Id.ToString());
            if (us == null)
            {
                serviceResponse.Code = ServiceResponseCodes.NotFoundUserById;
            }
            else
            {
                _uow.UserManager.Update(_mapper.Map(user, us));
                await _uow.SaveAsync();

                serviceResponse.Code = ServiceResponseCodes.Ok;
            }

            return serviceResponse;
        }

        public async Task<IServiceResponse> DeleteByIdAsync(int id)
        {
            LoggerContext.Logger.Info($"Delete user with id = {id}");

            ServiceResponse serviceResponse = new ServiceResponse();
            var us = await _uow.UserManager.FindByIdAsync(id.ToString());
            if (us == null)
            {
                serviceResponse.Code = ServiceResponseCodes.NotFoundUserById;
            }
            else
            {
                _uow.UserManager.Delete(us);
                await _uow.SaveAsync();

                serviceResponse.Code = ServiceResponseCodes.Ok;
            }

            return serviceResponse;
        }

        public async Task<IServiceResponse> GetByIdAsync(int id)
        {
            LoggerContext.Logger.Info($"Get user with id = {id}");

            ServiceResponse serviceResponse = new ServiceResponse();
            var user = await _uow.UserManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                serviceResponse.Code = ServiceResponseCodes.NotFoundUserById;
            }
            else
            {
                serviceResponse.Code = ServiceResponseCodes.Ok;
                serviceResponse.Content = _mapper.Map<User, EditUserDto>(user);
            }

            return serviceResponse;
        }

        public async Task<IServiceResponse> GetByEmailAsync(string email)
        {
            LoggerContext.Logger.Info($"Get user with email = {email}");

            ServiceResponse serviceResponse = new ServiceResponse();
            var user = await _uow.UserManager.FindByEmailAsync(email);
            if (user == null)
            {
                serviceResponse.Code = ServiceResponseCodes.NotFoundUserByEmail;
            }
            else
            {
                serviceResponse.Code = ServiceResponseCodes.Ok;
                serviceResponse.Content = _mapper.Map<User, EditUserDto>(user);
            }

            return serviceResponse;
        }

        public async Task<IServiceResponse> GetAllAsync()
        {
            //LoggerContext.Logger.Info("Get all users");

            //var users = await _uow.Users.GetAllAsync();
            //ServiceResponse serviceResponse = new ServiceResponse()
            //{
            //    Code = ServiceResponseCodes.Ok,
            //    Content = _mapper.Map<IReadOnlyCollection<User>, IReadOnlyCollection<EditUserDto>>(users)
            //};
            ServiceResponse serviceResponse = new ServiceResponse();
            serviceResponse.Code = ServiceResponseCodes.Ok;
            return serviceResponse;
        }
    }
}