using System.Collections.Generic;
using System.Linq;
using RedTeam.iTechArtSurvay.Foundation.DTO;

namespace RedTeam.iTechArtSurvay.Foundation.Interfaces
{
    public interface IUserService
    {
        void Create(UserDto user);
        void Update(UserDto user);
        void Delete(int id);
        UserDto Get(int id);
        IEnumerable<UserDto> GetAll();
        void Dispose();
    }
}