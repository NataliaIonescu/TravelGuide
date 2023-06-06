

using TravelGuide.Models;
using TravelGuide.Repositories.Interfaces;

namespace TravelGuide.Repositories
{
    public class CityTourRepository :Repository<CityTour>, ICityTourRepository
    {
        public CityTourRepository(TravelContext context) : base(context) { }
    }
}
