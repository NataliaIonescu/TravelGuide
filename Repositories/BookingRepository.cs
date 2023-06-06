using TravelGuide.Models;
using TravelGuide.Repositories.Interfaces;

namespace TravelGuide.Repositories
{
    public class BookingRepository: Repository<Booking>, IBookingRepository
    {
        public BookingRepository(TravelContext context) : base(context) { }
    }
}
