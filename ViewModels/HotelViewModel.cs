namespace TravelGuide.ViewModels
{
    public class HotelViewModel
    {
        public int HotelID { get; set; }
        public string HotelName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
