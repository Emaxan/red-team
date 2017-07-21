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

namespace RedTeam.TechArtSurvey.Foundation.Services
{
    [UsedImplicitly]
    public class SignupService : ISignupService
    {
        private readonly ITechArtSurveyUnitOfWork _uow;
        private readonly IMapper _mapper;


        public SignupService(ITechArtSurveyUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }


        public async Task<IServiceResponse> CreateAsync(UserDto user)
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
                _uow.Users.Create(_mapper.Map<UserDto, User>(user));
                await _uow.SaveAsync();

                serviceResponse.Code = ServiceResponseCodes.Ok;
            }

            return serviceResponse;
        }
    }
}