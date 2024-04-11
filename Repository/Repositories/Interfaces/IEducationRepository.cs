using Domain.Models;

namespace Repository.Repositories.Interfaces
{
    public interface IEducationRepository : IBaseRepository<Education>
    {
        Task<List<Education>> SearchAsync(string name);
        Task<List<Education>> GetAllWithGroupsAsync(string group);
        Task<List<Education>> SortWithCreatedDate(string date);
    }
}
