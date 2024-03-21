using application.Contracts.Persistences.Common;
using domain.Common.ValueObjects;
using domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Contracts.Persistences
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        Task<Account> GetByEmailAsync(Email email);
        //var account = await _accountRepository.GetByEmailAsync<Account>(account => account.Email == request.Email);

        /*namespace application.Persistences.Repositories
	{
		public class AccountRepository : IAccountRepository
		{
			// Triển khai các phương thức khác

			public async Task<Account> GetByEmail(string email)
			{
				return await GetByConditionAsync<Account>(account => account.Email == email);
			}
		}
	}*/

    }
}
