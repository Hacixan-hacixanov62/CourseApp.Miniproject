using Domain.Comman;
using Domain.Models;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Repository.Repositories.Interfaces
{
    public   interface IBaseRepository<T> where T : BaseEntity
    {
        Task CreateAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync(); 
      
    }
}
