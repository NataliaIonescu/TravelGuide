using TravelGuide.Repositories.Interfaces;

namespace TravelGuide.UnitOfWork.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        ICityRepository Cities { get; }
        ICityTourRepository CityTours { get; }
        IHotelRepository Hotels { get; }
        IOfferRepository Offers { get; }
        IBookingRepository Bookings { get; }

        Task<int> CompleteAsync();
    }
}
