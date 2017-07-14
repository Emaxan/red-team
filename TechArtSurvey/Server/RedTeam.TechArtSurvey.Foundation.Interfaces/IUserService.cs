using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedTeam.TechArtSurvey.Foundation.Interfaces
{
    public interface IUserService<TEntityDto>
        where TEntityDto : class, IEntityDto
    {
        Task Create(TEntityDto user);
        Task Update(TEntityDto user);
        Task DeleteAsync(int id);
        Task<TEntityDto> GetAsync(int id);
        Task<IReadOnlyCollection<TEntityDto>> GetAllAsync();
    }
}