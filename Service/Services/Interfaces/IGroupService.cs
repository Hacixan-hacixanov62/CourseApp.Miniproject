using Domain.Models;

namespace Service.Services.Interfaces
{
    public interface IGroupService
    {
        Task CreateAsync(Group group);
        Task UpdateAsync();
        Task DeleteAsync(int? id);
        Task<List<Group>> SearchAsync(string name);
        Task<List<Group>> GetAllAsync();    
        Task<List<Group>> FilterByEducationNameAsync(string name);
        Task<List<Group>> GetAllWithEducationIdAsync(int id);
        Task<List<Group>> SortWithCapacityAsync(string capacity);
        Task<Group> GetByIdAsync(int? id);

    }
}
