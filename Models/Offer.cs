using System.Diagnostics;

namespace TravelGuide.Models
{
    public class Offer
    {
        public int OfferID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public float Price { get; set; }


        public int HotelID { get; set; } // Required foreign key property
        public virtual Hotel? Hotel { get; set; } = null!;
        public int CityTourID { get; set; } // Required foreign key property
        public virtual CityTour? CityTour { get; set; } = null!;

        public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();

    }
}