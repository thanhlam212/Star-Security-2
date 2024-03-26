using Application.Contracts.Persistences;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Repositories.Common;
using StarSecurityAPI.Data;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories
{
    public class OfferRepository : GenericRepository<Offer>, IOfferRepository
	{
		public OfferRepository(StarSecurityAPIContext dbContext,
			ILogger<OfferRepository> logger)
			: base(dbContext,
				  logger)
		{
		}
	}
}