using AutoMapper;
using Microsoft.AspNet.Identity;
using RedTeam.Logger;
using RedTeam.Repositories.Identity.Security;
using RedTeam.TechArtSurvey.DomainModel.Entities;
using RedTeam.TechArtSurvey.Foundation.Dto.UsersDto;
using RedTeam.TechArtSurvey.Foundation.Interfaces;
using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;
using System.Threading.Tasks;

namespace RedTeam.TechArtSurvey.Foundation.Services
{
    public class ApplicationUserManager : UserManager<User, int>, IApplicationUserManager
    {
        private readonly IMapper _mapper;


        public ApplicationUserManager(IUserStore<User, int> store, IMapper mapper)
                : base(store)
        {
            _mapper = mapper;
        }
        
        
        public async Task<IServiceResponse> CreateAsync(UserDto userDto)
        {
            User user = await FindByEmailAsync(userDto.Email);
            ServiceResponse serviceResponse = new ServiceResponse();
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
                serviceResponse.Code = ServiceResponseCodes.NotFoundUserById;
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
                serviceResponse.Code = ServiceResponseCodes.NotFoundUserById;
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
                serviceResponse.Code = ServiceResponseCodes.NotFoundUserById;
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
            var user = await FindByEmailAsync(email);
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
