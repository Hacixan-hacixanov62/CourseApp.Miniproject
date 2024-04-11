using Domain.Models;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class EducationRepository : BaseRepository<Education>, IEducationRepository
    {
        public Task<List<Education>> GetAllWithGroupsAsync(string group)
        {
            throw new NotImplementedException();
        }

        public Task<List<Education>> SearchAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<Education>> SortWithCreatedDate(string date)
        {
            throw new NotImplementedException();
        }
    }
}
