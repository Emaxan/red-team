using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using JetBrains.Annotations;
using Microsoft.Owin.Security.OAuth;
using RedTeam.TechArtSurvey.Foundation.Interfaces;
using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;
using RedTeam.TechArtSurvey.Repositories.Interfaces;
using RedTeam.TechArtSurvey.Foundation.Dto.UsersDto;
using RedTeam.TechArtSurvey.DomainModel.Entities;
using RedTeam.Logger;
using RedTeam.TechArtSurvey.Foundation.Identity.Managers;
using RedTeam.TechArtSurvey.Foundation.Responses;

namespace RedTeam.TechArtSurvey.Foundation
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


        public async Task<IServiceResponse<UserDto>> CreateAsync(UserDto userDto)
        {
            var us = _mapper.Map<UserDto, User>(userDto);
            us.Role = await _roleManager.FindByNameAsync(default(RoleTypes).ToString());
            var result = await _userManager.CreateAsync(us, us.Password);
            if (!result.Succeeded)
            {
                return ServiceResponse.CreateUnsuccessful<UserDto>(ServiceResponseCode.UserAlreadyExists);
            }

            return ServiceResponse.CreateSuccessful(_mapper.Map<User, UserDto>(us));
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

            var us = await _uow.Users.GetByIdAsync(id);
            if (us == null)
            {
                return ServiceResponse.CreateUnsuccessful<object>(ServiceResponseCode.UserNotFoundById);
            }
            _uow.Users.Delete(us);

            return ServiceResponse.CreateSuccessful();
        }

        public async Task<IServiceResponse<EditUserDto>> GetByIdAsync(int id)
        {
            LoggerContext.Logger.Info($"Get user with id = {id}");

            var user = await _uow.Users.GetByIdAsync(id);
            if (user == null)
            {
                return ServiceResponse.CreateUnsuccessful<EditUserDto>(ServiceResponseCode.UserNotFoundById);
            }

            return ServiceResponse.CreateSuccessful(_mapper.Map<User, EditUserDto>(user));
        }
        
        public async Task<IServiceResponse> CheckByEmailAsync(string email)
        {
            LoggerContext.Logger.Info($"Get user with email = {email}");

            var user = await _uow.Users.GetUserByEmailAsync(email);
            return user == null ? 
                ServiceResponse.CreateSuccessful() : 
                ServiceResponse.CreateUnsuccessful<object>(ServiceResponseCode.UserAlreadyExists);
        }

        public async Task<IServiceResponse<IReadOnlyCollection<EditUserDto>>> GetAllAsync()
        {
            LoggerContext.Logger.Info("Get all users");

            var users = await _uow.Users.GetAllAsync();
            var mapped = _mapper.Map<IReadOnlyCollection<User>, IReadOnlyCollection<EditUserDto>>(users);

            return ServiceResponse.CreateSuccessful(mapped);
        }
    }
}
