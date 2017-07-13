using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RedTeam.iTechArtSurvay.Foundation.DTO;

namespace RedTeam.iTechArtSurvay.Foundation.Interfaces
{
    public interface IUserService
    {
        void Create(UserDto user);
        void Update(UserDto user);
        Task DeleteAsync(int id);
        Task<UserDto> GetAsync(int id);
        Task<IEnumerable<UserDto>> GetAllAsync();
        void Dispose();
    }
}