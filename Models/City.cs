using Microsoft.Extensions.Hosting;

namespace TravelGuide.Models
{
    public class City
    {
        public int CityID { get; set; }
        public string CityName { get; set; } = string.Empty;
        public string ImageName { get; set; } = string.Empty;

        public virtual ICollection<CityTour> CityTours { get; } = new List<CityTour>();

    }
}