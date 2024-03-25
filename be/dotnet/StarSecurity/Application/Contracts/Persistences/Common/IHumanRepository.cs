using Domain.Entities.Common;

namespace Application.Contracts.Persistences.Common
{
	public interface IHumanRepository<T> : IGenericRepository<T> where T : Human
	{
		Task<T> GetByEmailAsync(string email);
		Task<IEnumerable<T>> GetByNameAsync(string name);
		Task<IEnumerable<T>> GetByYearOfBirthAsync(int birthOfYear);
		Task<IEnumerable<T>> GetByGenderAsync(string gender);
	}
}
