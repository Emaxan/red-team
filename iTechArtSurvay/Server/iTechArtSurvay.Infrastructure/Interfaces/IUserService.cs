using System.Collections.Generic;
using iTechArtSurvay.Infrastructure.DTO;

namespace iTechArtSurvay.Infrastructure.Interfaces
{
    public interface IUserService
    {
        void Create(UserDto user);
        void Update(UserDto user);
        void Delete(int? id);
        UserDto Get(int? id);
        IEnumerable<UserDto> GetAll();
        void Dispose();
    }
}