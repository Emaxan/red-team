using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Identity;
using RedTeam.Identity.Security;
using RedTeam.Logger;
using RedTeam.TechArtSurvey.DomainModel.Entities;
using RedTeam.TechArtSurvey.Foundation.Dto.UsersDto;
using RedTeam.TechArtSurvey.Foundation.Interfaces;
using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;
using RedTeam.Identity.Responses;
using RedTeam.Identity.Stores;
using System;
using JetBrains.Annotations;

namespace RedTeam.Identity.Managers
{
    [UsedImplicitly]
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
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
        }
        
        
        public async Task<IServiceResponse> CreateAsync(UserDto userDto)
        {
            var us = _mapper.Map<UserDto, User>(userDto);
            await CreateAsync(us, us.Password);
            await AddToRoleAsync(us.Id, default(RoleTypes).ToString());
//            if (userDto.Role == null)
//            {
//                userDto.Role = new RoleDto();
//            }
//            us.Role = new Role()
//            {
//                RoleType = (RoleTypes)Enum.Parse(typeof(RoleTypes), userDto.Role.Name)
//            };

            return ServiceResponse.CreateSuccessful(us);
        }

        public async Task<IServiceResponse> GetClaimsByCredentialsAsync(string email, string password)
        {
            var user = await FindByEmailAsync(email);
            if (user == null)
            {
                return ServiceResponse.CreateUnsuccessful(ServiceResponseCodes.UserNotFoundByEmail);
            }
            if (PasswordHasher.VerifyHashedPassword(user.Password, password) != PasswordVerificationResult.Success)
            {
                return ServiceResponse.CreateUnsuccessful(ServiceResponseCodes.InvalidPassword);
            }
            var claims = ClaimsManager.GetClaims(user);

            return ServiceResponse.CreateSuccessful(claims);
        }

        public async Task<IServiceResponse> UpdateAsync(EditUserDto user)
        {
            LoggerContext.Logger.Info($"Update user with email = {user.Email}");

            var us = await FindByIdAsync(user.Id);
            if (us == null)
            {
                return ServiceResponse.CreateUnsuccessful(ServiceResponseCodes.UserNotFoundById);
            }
            await UpdateAsync(_mapper.Map(user, us));

            return ServiceResponse.CreateSuccessful(null);
        }

        public async Task<IServiceResponse> DeleteByIdAsync(int id)
        {
            LoggerContext.Logger.Info($"Delete user with id = {id}");

            var us = await FindByIdAsync(id);
            if (us == null)
            {
                return ServiceResponse.CreateUnsuccessful(ServiceResponseCodes.UserNotFoundById);
            }
            await DeleteAsync(us);

            return ServiceResponse.CreateSuccessful(null);
        }

        public async Task<IServiceResponse> GetByIdAsync(int id)
        {
            LoggerContext.Logger.Info($"Get user with id = {id}");

            var user = await FindByIdAsync(id);
            if (user == null)
            {
                return ServiceResponse.CreateUnsuccessful(ServiceResponseCodes.UserNotFoundById);
            }

            return ServiceResponse.CreateSuccessful(_mapper.Map<User, EditUserDto>(user));
        }

        public async Task<IServiceResponse> CheckByEmailAsync(string email)
        {
            LoggerContext.Logger.Info($"Get user with email = {email}");

            var user = await FindByEmailAsync(email);
            if (user == null)
            {
                return ServiceResponse.CreateSuccessful(null);
            }

            return ServiceResponse.CreateUnsuccessful(ServiceResponseCodes.UserAlreadyExists);
        }

        public async Task<IServiceResponse> GetAllAsync()
        {
            LoggerContext.Logger.Info("Get all users");
            var users = await _store.GetAllAsync();
            var mapped = _mapper.Map<IReadOnlyCollection<User>, IReadOnlyCollection<EditUserDto>>(users);

            return ServiceResponse.CreateSuccessful(mapped);
        }
    }
}