using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Xml.Linq;

namespace Repository.Repositories
{
    public class EducationRepository : BaseRepository<Education>, IEducationRepository
    {
        private readonly AppDbContext _context;

        public EducationRepository()
        {

            _context = new AppDbContext();
        }

        public async Task<List<Education>> GetAllWithGroupsAsync(string group)
        {
            return await _context.Set<Education>().ToListAsync();
        }

        public async Task<List<Education>> SearchAsync(string name)
        {
            return await _context.Set<Education>().Where<Education>(m=>m.Name.ToLower().Trim().Contains(name.ToLower().Trim())).ToListAsync();

            // return Task<Education>Where( m.Name.Contains(name)).ToList();
        }

        public async Task<List<Education>> SortWithCreatedDate(string date)
        {
            //return await _context.Set<Education>().Include(date).ToListAsync();

            return await _context.Set<Education>().Where<Education>(m =>m.Name.ToLower().Trim().Contains(date.ToLower().Trim())).ToListAsync();
        }
    }
}
