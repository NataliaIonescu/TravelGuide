namespace TravelGuide.ViewModels
{
    public class CityTourViewModel
    {
        public int CityTourID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Itinerary { get; set; } = string.Empty;
        public float Duration { get; set; }
        public int CityID { get; set; }
       
    }
}
