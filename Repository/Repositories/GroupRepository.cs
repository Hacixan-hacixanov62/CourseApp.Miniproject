using Domain.Models;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        public Task<List<Group>> FilterByEducationNameAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Group>> GetAllWithEducationIdAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Group>> SearchAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Group>> SortWithCapacityAsync()
        {
            throw new NotImplementedException();
        }
    }
}
