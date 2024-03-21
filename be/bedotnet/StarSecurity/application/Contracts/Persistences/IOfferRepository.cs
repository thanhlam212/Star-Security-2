using application.Contracts.Persistences.Common;
using domain.Entities;

namespace application.Contracts.Persistences
{
    public interface IOfferRepository : IGenericRepository<Offer>
    {
        //GetExpiredOffersAsync
    }
}
