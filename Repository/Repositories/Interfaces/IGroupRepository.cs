using Domain.Models;


namespace Repository.Repositories.Interfaces
{
    public interface IGroupRepository : IBaseRepository<Group>
    {
      
        Task<List<Group>> SearchAsync();
        Task<List<Group>> FilterByEducationNameAsync();
        Task<List<Group>>GetAllWithEducationIdAsync();
        Task<List<Group>> SortWithCapacityAsync();



    }
}
