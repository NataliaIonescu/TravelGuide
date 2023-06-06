namespace TravelGuide.Services.Interfaces
{
    public interface ICityService
    {
        Task<List<string>> GetCityNamesWhichContainTerm(string term);
    }
}
