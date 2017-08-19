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
    public class ApplicationUserManager : UserManager<User, int>
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


        public async Task<IReadOnlyCollection<User>> GetAllAsync()
        {
            return await _store.GetAllAsync();
        }
    }
}