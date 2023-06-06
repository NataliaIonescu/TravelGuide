using TravelGuide.Models;
using TravelGuide.Repositories.Interfaces;

namespace TravelGuide.Repositories
{
    public class HotelRepository : Repository<Hotel>, IHotelRepository
    {
        public HotelRepository(TravelContext context) : base(context) { }
    }

}
