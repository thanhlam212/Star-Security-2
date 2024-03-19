using domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace application.Persistences.Contracts.Common
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IReadOnlyCollection<T>> GetAllReadOnlyAsync();
        Task<IEnumerable<T>> GetAllAsync();
        //Task<T> GetByConditionAsync<TValue>(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdAsync(Guid Id);

		//Get all but deleted
		Task<IEnumerable<T>> GetAllWithoutDeletedAsync();
		Task<T> GetByIdWithoutAsync(Guid Id);

		Task<bool> AddAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<bool> UpdateAsync(T entity);

    }
}
