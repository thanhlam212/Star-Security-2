using domain.Common.ValueObjects;
using domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace application.Contracts.Persistences.Common
{
    public interface IGenericRepository<T> where T : class
    {
        //Task<IReadOnlyCollection<T>> GetAllReadOnlyAsync();
        //Task<IEnumerable<T>> GetNotDeletedAsync();
        //Task<T> GetByConditionAsync<TValue>(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);

        Task<bool> AddAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<bool> UpdateAsync(T entity);

    }
}
