using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedTeam.TechArtSurvey.Foundation.Interfaces
{
    public interface IUserService<TEntityDto>
        where TEntityDto : class, IEntityDto
    {
        void Create(TEntityDto user);
        void Update(TEntityDto user);
        Task DeleteAsync(int id);
        Task<TEntityDto> GetAsync(int id);
        Task<IEnumerable<TEntityDto>> GetAllAsync();
        void Dispose();
    }
}