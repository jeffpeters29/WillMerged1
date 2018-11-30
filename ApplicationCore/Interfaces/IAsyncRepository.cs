using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities.Common;

namespace ApplicationCore.Interfaces
{
    public interface IAsyncRepository<T> where T : EntityBase
    {
        Task<T> GetByIdAsync(Guid id);
        Task<List<T>> ListAllAsync();
        Task<List<T>> ListAsync(ISpecification<T> spec);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
