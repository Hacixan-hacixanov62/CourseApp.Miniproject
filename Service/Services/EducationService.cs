using Domain.Models;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Helpers.Constans;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;
using System.Xml.Linq;

namespace Service.Services
{
    public class EducationService : IEducationService
    {
        private readonly IEducationRepository _educationRepository;
       
        public EducationService()
        {
            _educationRepository = new EducationRepository();   
        }

        public async Task CreateAsync(Education data)
        {
            if (data == null) throw new NotImplementedException();
            await  _educationRepository.CreateAsync(data);
           
        }

        public async Task DeleteAsync(int? id)
        {
            if (id == null) throw new ArgumentNullException();

           Education education = await _educationRepository.GetByIdAsync((int)id);

            if (education is null) throw new NotFoundExceptions(ResponseMessages.DataNotFound);

           await _educationRepository.DeleteAsync(education);

        }

        public async Task<List<Education>> GetAllAsync()
        {
            return await _educationRepository.GetAllAsync();
        }

        public async Task<List<Education>> GetAllWithGroupsAsync()
        {
            
            return await _educationRepository.GetAllWithGroupsAsync();
          
        }

        public async Task<Education> GetByIdAsync(int? id)
        {
            if (id == null) throw new NotImplementedException();

           Education education = await _educationRepository.GetByIdAsync((int)id);

            if (education is null)
            {
                throw new NotFoundExceptions(ResponseMessages.DataNotFound);
            }

            return education;
        }

        public async Task<List<Education>> SearchAsync(string name)
        {
            return await _educationRepository.SearchAsync(name);
        }

        public async Task<List<Education>> SortWithCreatedDateAsync(string date)
        {
            return await _educationRepository.SortWithCreatedDateAsync(date);
        }

        public async Task UpdateAsync(Education data)
        {
            await _educationRepository.Groups.UpdateAsync(group);
            _educationRepository.SaveChangesAsync();

        }


    }

    
}
