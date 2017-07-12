using System.Collections.Generic;
using iTechArtSurvay.Domain.Models;

namespace iTechArtSurvay.Infrastructure.Repositores.Abstract
{
    public interface IUserRepository
    {
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        User GetUser(int id);
        IEnumerable<User> GetUsers();
    }
}