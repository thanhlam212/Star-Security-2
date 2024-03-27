using Application.Contracts.Persistences;
using Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using StarSecurityAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly StarSecurityAPIContext _context;
		private readonly ILoggerFactory _loggerFactory;

		private IAccountRepository _accountRepository;

		private IBranchRepository _branchRepository;

		private IClientRepository _clientRepository;

		private IEmployeeRepository _employeeRepository;

		private IOfferRepository _offerRepository;
        public UnitOfWork(StarSecurityAPIContext context, ILoggerFactory loggerFactory)
		{
			_context = context;
			_loggerFactory = loggerFactory;

		}
		public IAccountRepository AccountRepository => _accountRepository 
			?? new AccountRepository(_context, _loggerFactory.CreateLogger<AccountRepository>());

		public IBranchRepository BranchRepository => _branchRepository
			?? new BranchRepository(_context, _loggerFactory.CreateLogger<BranchRepository>());
		public IClientRepository ClientRepository => _clientRepository
			?? new ClientRepository(_context, _loggerFactory.CreateLogger<ClientRepository>());
		public IEmployeeRepository EmployeeRepository => _employeeRepository
			?? new EmployeeRepository(_context, _loggerFactory.CreateLogger<EmployeeRepository>());
		public IOfferRepository OfferRepository => _offerRepository
			?? new OfferRepository(_context, _loggerFactory.CreateLogger<OfferRepository>());
		public async Task CompleteAsync()
		{
			await _context.SaveChangesAsync();
		}

		public async void Dispose()
		{
			await _context.DisposeAsync();
		}
	}
}
