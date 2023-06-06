using Microsoft.AspNetCore.Identity;


namespace TravelGuide.Models
{
    public class AppUser :IdentityUser
    {
        public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();

    }
}