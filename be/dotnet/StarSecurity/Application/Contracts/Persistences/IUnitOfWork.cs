using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistences
{
	public interface IUnitOfWork : IDisposable
	{
		IAccountRepository AccountRepository { get; }
		IBranchRepository BranchRepository { get; }
		IClientRepository ClientRepository { get; }
		IEmployeeRepository EmployeeRepository { get; }
		IOfferRepository OfferRepository { get; }
		Task CompleteAsync();
	}
}
