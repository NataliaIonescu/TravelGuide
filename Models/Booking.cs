

using Microsoft.CodeAnalysis.Differencing;

namespace TravelGuide.Models
{
    public class Booking
    {
        public int BookingID { get; set; }
       
     //   public DateTime CreationDate { get; set; }
        public int OfferID { get; set; }
        public virtual Offer Offer { get; set; } = null!;

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string CardNumber { get; set; } = string.Empty; //  Debit/Credit card number
        public DateTime ExpirationDate { get; set; }
        public string SecurityCode { get; set; } = string.Empty;

        // public string AppUserID { get; set; }
        // public virtual AppUser AppUser { get; set; } = null!;
    }
}
