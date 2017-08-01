using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.OAuth;
using RedTeam.Logger;
using RedTeam.TechArtSurvey.DomainModel.Entities;
using RedTeam.TechArtSurvey.Foundation.Dto.UsersDto;
using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;
using RedTeam.TechArtSurvey.Repositories.Interfaces;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RedTeam.TechArtSurvey.Foundation.Services
{ 
      //usermanager
     //userstore
     //uow

    //repository

    public class ApplicationUserManager : UserManager<User, int>
    {
        private readonly IMapper _mapper;

        public ApplicationUserManager(IUserStore<User, int> store, IMapper mapper)
                : base(store)
        {
            _mapper = mapper;
        }


        private ClaimsIdentity GetClaims(User user)
        {
            var claims = new ClaimsIdentity(OAuthDefaults.AuthenticationType);
            claims.AddClaim(new Claim(ClaimTypes.Email, user.Email));
            claims.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            claims.AddClaim(new Claim(ClaimTypes.Role, user.Role.RoleName.ToString()));
            return claims;
        }
        public async Task<IServiceResponse> CreateAsync(UserDto userDto)
        {
            User user = await FindByEmailAsync(userDto.Email);
            ServiceResponse serviceResponse = new ServiceResponse();
            if (user == null)
            {
                userDto.Password = PasswordHasher.HashPassword(userDto.Password);
                var us = _mapper.Map<UserDto, User>(userDto);

                var role = RoleManager.FindByRoleNameAsync(RoleNames.User);
                us.Role = role.Result;
                await _uow.UserManager.CreateAsync(us);

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

        public async Task<IServiceResponse> GetClaimsByCredentialsAsync(string email, string password)
        {
            ServiceResponse serviceResponse = new ServiceResponse();
            var user = await _uow.UserManager.FindByEmailAsync(email);
            if (user == null)
            {
                serviceResponse.Code = ServiceResponseCodes.NotFoundUserById;
            }
            else if (_uow.UserManager.PasswordHasher.VerifyHashedPassword(user.Password, password) != PasswordVerificationResult.Success)
            {
                serviceResponse.Code = ServiceResponseCodes.InvalidPassword;
            }
            else
            {
                serviceResponse.Code = ServiceResponseCodes.Ok;
                var claims = GetClaims(user);
                serviceResponse.Content = claims;
            }

            return serviceResponse;
        }

        public async Task<IServiceResponse> UpdateAsync(EditUserDto user)
        {
            LoggerContext.Logger.Info($"Update user with email = {user.Email}");

            ServiceResponse serviceResponse = new ServiceResponse();
            var us = await _uow.UserManager.FindByIdAsync(user.Id);
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
            var us = await _uow.UserManager.FindByIdAsync(id);
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
            var user = await _uow.UserManager.FindByIdAsync(id);
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
    }
}
