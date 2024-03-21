using application.Contracts.Persistences;
using domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Common;

namespace Persistence.Repositories
{
    public class OfferRepository : GenericRepository<Offer>, IOfferRepository
	{
		public OfferRepository(StarSecurityDbContext dbContext, DbSet<Offer> dbSet) : base(dbContext, dbSet)
		{
		}
	}
}