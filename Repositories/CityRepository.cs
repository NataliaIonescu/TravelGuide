using TravelGuide.Repositories.Interfaces;
using TravelGuide.Models;


namespace TravelGuide.Repositories
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(TravelContext context) : base(context) { }
    }

}
