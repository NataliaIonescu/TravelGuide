namespace TravelGuide.Models
{
    public class Hotel
    {
        public int HotelID { get; set; }
        public string HotelName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public virtual ICollection<Offer> Offers { get; } = new List<Offer>();
    }
}

