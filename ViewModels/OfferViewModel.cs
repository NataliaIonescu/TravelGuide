namespace TravelGuide.ViewModels
{
    public class OfferViewModel
    {
        public int OfferID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public float Price { get; set; }
        public int HotelID { get; set; }
        public int CityTourID { get; set; }
    }
}
