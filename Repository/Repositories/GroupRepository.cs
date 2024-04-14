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
       
        public GroupRepository()
        {
            _context = new AppDbContext();
        }

        public async Task<List<Group>> FilterByEducationNameAsync(string name)
        {

            return await _context.Set<Group>().Include(m=>m.Education).Where(m=>m.Education.Name.ToLower().Trim().Contains(name.ToLower().Trim())).ToListAsync(); 

        }

        public async Task<List<Group>> GetAllWithEducationIdAsync(int id)
        {
            return await _context.Set<Group>().Where(m => m.EducationId == id).ToListAsync();

        }

        public async Task<List<Group>> SearchAsync(string searchtext)
        {
            return await _context.Set<Group>().Where(m => m.Name.ToLower().Trim().Contains(searchtext.ToLower().Trim())).ToListAsync();
        }
        
        public async Task<List<Group>> SortWithCapacityAsync(string capacity)
        {
            if (capacity == "desc")
            {
                return await _context.Set<Group>().OrderByDescending(m => m.Capacity).ToListAsync();
            }
            else if (capacity == "asc")
            {
                return await _context.Set<Group>().OrderBy(m => m.Capacity).ToListAsync();
            }
            else
            {
                return null;
            }

        }

    }
}
