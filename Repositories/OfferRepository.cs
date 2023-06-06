using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TravelGuide.Models;
using TravelGuide.Repositories.Interfaces;

namespace TravelGuide.Repositories
{
    public class OfferRepository : Repository<Offer>, IOfferRepository
    {
        private readonly TravelContext _context;
        public OfferRepository(TravelContext context) : base(context) { _context = context; }

        public async Task LoadRelatedEntitiesAsync(Offer offer, params Expression<Func<Offer, object>>[] includeProperties)
        {
            foreach (var includeProperty in includeProperties)
            {
                await _context.Entry(offer).Reference(includeProperty).LoadAsync();
            }
        }

    }

}
