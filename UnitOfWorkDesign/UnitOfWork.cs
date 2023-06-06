using TravelGuide.Models;
using TravelGuide.Repositories;
using TravelGuide.Repositories.Interfaces;
using TravelGuide.UnitOfWork.Interface;

namespace TravelGuide.UnitOfWorkDesign
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TravelContext _context;

        public UnitOfWork(TravelContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
            Cities = new CityRepository(_context);
            CityTours = new CityTourRepository(_context);
            Hotels = new HotelRepository(_context);
            Bookings = new BookingRepository(_context);
            Offers = new OfferRepository(_context);
        }

        public IUserRepository Users { get; private set; }

        public ICityRepository Cities { get; private set; }

        public ICityTourRepository CityTours { get; private set; }

        public IHotelRepository Hotels { get; private set; }

        public IBookingRepository Bookings { get; private set; }

        public IOfferRepository Offers { get; private set; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose() 
        {
            _context.Dispose();
        }
    }
}
