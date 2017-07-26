﻿using System.Threading.Tasks;
using System.Web.Http;

using RedTeam.Logger;
using RedTeam.TechArtSurvey.Foundation.Dto.UsersDto;
using RedTeam.TechArtSurvey.Foundation.Interfaces;
using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;
using Ninject;
using RedTeam.TechArtSurvey.WebApi.Provider;

namespace RedTeam.TechArtSurvey.WebApi.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;
        private IKernel _kernel;

        public UsersController(IUserService userService, IKernel kernel)
        {
            _userService = userService;
            _kernel = kernel;
            _kernel.Get<SimpleAuthorizationServerProvider>();
        }


        // POST api/Users
        [HttpPost]
        public async Task<IServiceResponse> AddUser(UserDto user)
        {
            LoggerContext.Logger.Info($"Create User with email = {user.Email}");
            return await _userService.CreateAsync(user);
        }

        // PUT api/Users/5
        [HttpPut]
        public async Task<IServiceResponse> EditUser(EditUserDto user)
        {
            LoggerContext.Logger.Info($"Update User with email = {user.Email}");
            return await _userService.UpdateAsync(user);
        }

        // DELETE api/Users
        [HttpDelete]
        public async Task<IServiceResponse> RemoveUser(int id)
        {
            LoggerContext.Logger.Info($"Delete User with id = {id}");
            return await _userService.DeleteByIdAsync(id);
        }

        // GET api/Users/5
        [HttpGet]
        public async Task<IServiceResponse> GetUser(int id)
        {
            LoggerContext.Logger.Info($"Get User with id = {id}");
            return await _userService.GetByIdAsync(id);
        }

        // GET api/Users/?email=user@user.user
        [HttpGet]
        public async Task<IServiceResponse> GetUserByEmail([FromUri] string email)
        {
            LoggerContext.Logger.Info($"Get User with email = {email}");
            return await _userService.GetByEmailAsync(email);
        }

        // GET api/Users
        [HttpGet]
        public async Task<IServiceResponse> GetUsers()
        {
            LoggerContext.Logger.Info("Get all users");
            return await _userService.GetAllAsync();
        }
    }
}