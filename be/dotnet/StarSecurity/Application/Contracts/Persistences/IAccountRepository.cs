using Application.Contracts.Persistences.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.Contracts.Persistences
{
	public interface IAccountRepository : IGenericRepository<Account>
	{
		Task<Account> GetByEmailAsync(string email);
	}
}
