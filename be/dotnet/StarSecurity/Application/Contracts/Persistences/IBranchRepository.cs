using Application.Contracts.Persistences.Common;
using Domain.Entities;

namespace Application.Contracts.Persistences
{
	public interface IBranchRepository : IGenericRepository<Branch>
	{
		Task<Branch> GetByIdAsync(Guid id);
	}
}
