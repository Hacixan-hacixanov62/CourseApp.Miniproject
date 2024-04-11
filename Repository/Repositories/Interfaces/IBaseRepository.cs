using Domain.Comman;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Repository.Repositories.Interfaces
{
    public   interface IBaseRepository<T> where T : BaseEntity
    {
        Task DeleteAsync(T entity);
        Task UpdateAsync(int id);
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync(); 
      
    }
}
