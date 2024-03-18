using domain.Common.Abstractions;
using domain.Common.ValueObjects;
using domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Persistences.Contracts.Common
{
	public interface IHumanRepository<T> : IGenericRepository<T> where T : Human
	{
		Task<Account> GetByEmailAsync(Email email);

	}
}
