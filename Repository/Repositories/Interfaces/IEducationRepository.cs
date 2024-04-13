using Domain.Models;

namespace Repository.Repositories.Interfaces
{
    public interface IEducationRepository : IBaseRepository<Education>
    {
        Task<List<Education>> SearchAsync(string name);
        Task<List<Education>> GetAllWithGroupsAsync();
        Task<List<Education>> SortWithCreatedDateAsync(string date);
    }
}
