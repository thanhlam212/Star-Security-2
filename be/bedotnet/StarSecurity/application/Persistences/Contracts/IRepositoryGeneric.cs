using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace application.Persistences.Contracts
{
	public interface IGenericRepository<T> where T : class
	{
		Task<IReadOnlyCollection<T>> GetAllReadOnlyAsync();
		Task<IEnumerable<T>> GetAllAsync();
		Task<T> GetByConditionAsync<TValue>(Expression<Func<T, bool>> predicate);

		Task<bool> AddAsync(T entity);
		Task<bool> RemoveAsync(T entity);
		Task<bool> UpdateAsync(T entity);
		//Task<int> Count();
	}
}
