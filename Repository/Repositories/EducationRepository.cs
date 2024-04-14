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

        public async Task CreateAsync(Education education)
        {
            await _context.Educations.AddAsync(education);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Education>> GetAllWithGroupsAsync()
        {
            var educations = await _context.Set<Education>().Include(m=>m.Groups).ToListAsync();

             
            if (educations.Count == 0)
            {
                await Console.Out.WriteLineAsync("Data not found");
            }
            return educations;
        }

        public async Task<List<Education>> SearchAsync(string name)
        {
            return await _context.Set<Education>().Where<Education>(m=>m.Name.ToLower().Trim().Contains(name.ToLower().Trim())).ToListAsync();

            // return Task<Education>Where( m.Name.Contains(name)).ToList();
        }

        public async Task<List<Education>> SortWithCreatedDateAsync(string date)
        {
            //return await _context.Set<Education>().Include(date).ToListAsync();

            if (date == "desc")
            {
                return await _context.Set<Education>().OrderByDescending(m => m.CreatedDate).ToListAsync();
            }
            else if (date == "asc")
            {
                return await _context.Set<Education>().OrderBy(m => m.CreatedDate).ToListAsync();
            }
            else
            {
                return null;
            }


           
        }
    }
}
