using TravelGuide.Repositories.Interfaces;
using TravelGuide.Services.Interfaces;
using TravelGuide.UnitOfWork.Interface;

namespace TravelGuide.Services
{
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<string>> GetCityNamesWhichContainTerm(string term)
        {
            var cities = await _unitOfWork.Cities.GetAllAsync();
            var cityNames = cities.Where(c => c.CityName.Contains(term))
                                    .Select(p => p.CityName).ToList();
            return cityNames;
        }
    }
}
