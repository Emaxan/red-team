﻿using RedTeam.Logger;
using RedTeam.Repositories.EntityFramework.Repositories;
using RedTeam.Repositories.Interfaces;
using RedTeam.TechArtSurvey.Repositories.Interfaces.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using RedTeam.TechArtSurvey.DomainModel.Entities.Users;

namespace RedTeam.TechArtSurvey.Repositories.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IDbContext context)
            : base(context)
        {

        }


        public async Task<User> GetUserByEmailAsync(string email)
        {
            LoggerContext.Logger.Info($"Get User with email = {email}");

            return await DbSet.Include(r => r.Role).SingleOrDefaultAsync(u => u.Email == email);
        }

        public override async Task<User> GetByIdAsync(int id)
        {
            LoggerContext.Logger.Info($"Get User with id = {id}");

            return await DbSet.Where(u => u.Id == id).Include(r => r.Role).SingleOrDefaultAsync();
        }

        public override async Task<IReadOnlyCollection<User>> GetAllAsync()
        {
            return await DbSet.Include(r => r.Role).ToListAsync();
        }
    }
}