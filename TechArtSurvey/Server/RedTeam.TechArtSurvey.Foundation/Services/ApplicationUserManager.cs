using AutoMapper;
using Microsoft.AspNet.Identity;
using RedTeam.Logger;
using RedTeam.Identity.Security;
using RedTeam.TechArtSurvey.DomainModel.Entities;
using RedTeam.TechArtSurvey.Foundation.Dto.UsersDto;
using RedTeam.TechArtSurvey.Foundation.Interfaces;
using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;
using System.Threading.Tasks;
using RedTeam.Identity.Stores;
using System.Collections.Generic;

namespace RedTeam.TechArtSurvey.Foundation.Services
{
    public class ApplicationUserManager : UserManager<User, int>, IApplicationUserManager
    {
        private readonly IMapper _mapper;
        private readonly IApplicationUserStore _store;


        public ApplicationUserManager(IApplicationUserStore store, IMapper mapper)
                : base(store)
        {
            _store = store;
            _mapper = mapper;
            UserValidator = new UserValidator<User, int>(this)
            {
                AllowOnlyAlphanumericUserNames = false
            };
        }
        
        
        public async Task<IServiceResponse> CreateAsync(UserDto userDto)
        {
            ServiceResponse serviceResponse = new ServiceResponse();
            User user = await FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                userDto.Password = PasswordHasher.HashPassword(userDto.Password);
                var us = _mapper.Map<UserDto, User>(userDto);
                await CreateAsync(us);
                serviceResponse.Code = ServiceResponseCodes.Ok;

                return serviceResponse;
            }
            else
            {
                serviceResponse.Code = ServiceResponseCodes.UserAlreadyExists;
                return serviceResponse;
            }
        }

        public async Task<IServiceResponse> GetClaimsByCredentialsAsync(string email, string password)
        {
            ServiceResponse serviceResponse = new ServiceResponse();
            var user = await FindByEmailAsync(email);
            if (user == null)
            {
                serviceResponse.Code = ServiceResponseCodes.UserNotFoundByEmail;
            }
            else if (PasswordHasher.VerifyHashedPassword(user.Password, password) != PasswordVerificationResult.Success)
            {
                serviceResponse.Code = ServiceResponseCodes.InvalidPassword;
            }
            else
            {
                serviceResponse.Code = ServiceResponseCodes.Ok;
                var claims = ClaimsManager.GetClaims(user);
                serviceResponse.Content = claims;
            }

            return serviceResponse;
        }

        public async Task<IServiceResponse> UpdateAsync(EditUserDto user)
        {
            LoggerContext.Logger.Info($"Update user with email = {user.Email}");

            ServiceResponse serviceResponse = new ServiceResponse();
            var us = await FindByIdAsync(user.Id);
            if (us == null)
            {
                serviceResponse.Code = ServiceResponseCodes.UserNotFoundById;
            }
            else
            {
                await UpdateAsync(_mapper.Map(user, us));
                serviceResponse.Code = ServiceResponseCodes.Ok;
            }

            return serviceResponse;
        }

        public async Task<IServiceResponse> DeleteByIdAsync(int id)
        {
            LoggerContext.Logger.Info($"Delete user with id = {id}");

            ServiceResponse serviceResponse = new ServiceResponse();
            var us = await FindByIdAsync(id);
            if (us == null)
            {
                serviceResponse.Code = ServiceResponseCodes.UserNotFoundById;
            }
            else
            {
                await DeleteAsync(us);
                serviceResponse.Code = ServiceResponseCodes.Ok;
            }

            return serviceResponse;
        }

        public async Task<IServiceResponse> GetByIdAsync(int id)
        {
            LoggerContext.Logger.Info($"Get user with id = {id}");

            ServiceResponse serviceResponse = new ServiceResponse();
            var user = await FindByIdAsync(id);
            if (user == null)
            {
                serviceResponse.Code = ServiceResponseCodes.UserNotFoundById;
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
            var user = await FindByEmailAsync(email);
            if (user == null)
            {
                serviceResponse.Code = ServiceResponseCodes.UserNotFoundByEmail;
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
            LoggerContext.Logger.Info("Get all users");
            var users = await _store.GetAllAsync();
            ServiceResponse serviceResponse = new ServiceResponse()
            {
                Code = ServiceResponseCodes.Ok,
                Content = _mapper.Map<IReadOnlyCollection<User>, IReadOnlyCollection<EditUserDto>>(users)
            };

            return serviceResponse;
        }
    }
}
