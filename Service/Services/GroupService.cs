using Domain.Models;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Helpers.Constans;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        public GroupService()
        {

            _groupRepository = new GroupRepository();
        }


        public Task UpdateAsync()
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int? id)
        {
            if (id == null) throw new ArgumentNullException();

           Group group = await _groupRepository.GetByIdAsync((int)id);

            if (group is null) throw new NotFoundExceptions(ResponseMessages.DataNotFound);

            await _groupRepository.DeleteAsync(group);
        }

        public async Task<List<Group>> SearchAsync(string name)
        {
            return await _groupRepository.SearchAsync(name);
        }

        public async Task<List<Group>> GetAllAsync()
        {
            return await _groupRepository.GetAllAsync();
        }

        public async Task<List<Group>> FilterByEducationNameAsync(string name )
        {
            return await _groupRepository.FilterByEducationNameAsync(name);
        }

        public async Task<List<Group>> GetAllWithEducationIdAsync(int id)
        {
            return await _groupRepository.GetAllWithEducationIdAsync(id);
        }

        public async Task<List<Group>> SortWithCapacityAsync(string capacity)
        {
            return await _groupRepository.SortWithCapacityAsync(capacity);
        }

        public async Task<Group> GetByIdAsync(int? id)
        {
            if (id == null) throw new ArgumentNullException();

           Group group = await _groupRepository.GetByIdAsync((int)id);

            if (group is null)
            {
                throw new NotFoundExceptions(ResponseMessages.DataNotFound);
            }

            return group;
        }

        public Task CreateAsync()
        {
            throw new NotImplementedException();
        }
    }
}
