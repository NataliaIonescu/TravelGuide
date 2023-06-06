using System.Linq.Expressions;
using TravelGuide.Models;

namespace TravelGuide.Repositories.Interfaces
{
    public interface IOfferRepository : IRepository<Offer>
    {
        // Add the following method to the IOfferRepository interface
        Task LoadRelatedEntitiesAsync(Offer offer, params Expression<Func<Offer, object>>[] includeProperties);

    }
}
