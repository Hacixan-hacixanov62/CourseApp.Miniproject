using Domain.Models;

namespace Service.Services.Interfaces
{
    public interface IEducationService
    {
        Task CreateAsync(Education data);
        Task UpdateAsync(Education data);
        Task DeleteAsync(int? id);
        Task<List<Education>> SearchAsync(string name);
        Task<List<Education>> GetAllWithGroupsAsync();
        Task<List<Education>> SortWithCreatedDateAsync(string date);
        Task<List<Education>> GetAllAsync();
        Task<Education> GetByIdAsync(int? id);

    }
}   
