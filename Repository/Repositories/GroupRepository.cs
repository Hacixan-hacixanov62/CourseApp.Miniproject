using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System.Linq;
using System.Xml.Linq;


namespace Repository.Repositories
{
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {

        private readonly AppDbContext _context;
        private object stringList;

        public GroupRepository()
        {
            _context = new AppDbContext();
        }

        public Task<List<Group>> FilterByEducationNameAsync(string name)
        {

            throw new NotImplementedException();

            //var MS = Group.FilterByEducationNameAsync().OrderBy(x => x.Branch).ToList();
            //var MS = stringList.OrderBy(name => name);
        }

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
