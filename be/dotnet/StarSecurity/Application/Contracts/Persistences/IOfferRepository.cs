using Application.Contracts.Persistences.Common;
using Domain.Entities;

namespace Application.Contracts.Persistences
{
	public interface IOfferRepository : IGenericRepository<Offer>
	{
		//GetExpiredOffersAsync
	}
}
