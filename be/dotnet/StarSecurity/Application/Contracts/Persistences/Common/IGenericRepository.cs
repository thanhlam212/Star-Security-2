namespace Application.Contracts.Persistences.Common
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
