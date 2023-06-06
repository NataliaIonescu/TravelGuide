using System;
using System.Reflection.Metadata;

namespace TravelGuide.Models
{
    public class CityTour
    {
        public int CityTourID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Itinerary { get; set; } = string.Empty;
        
        public float Duration { get; set; }

        public int CityID { get; set; } // Required foreign key property
        public virtual City City { get; set; } = null!;

        
        public virtual ICollection<Offer> Offers { get; } = new List<Offer>();

    }
}