namespace TravelGuide.ViewModels
{
    public class BookingViewModel
    {
        public int BookingID { get; set; }
        public int OfferID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string CardNumber { get; set; } = string.Empty; //  Debit/Credit card number
        public DateTime ExpirationDate { get; set; }
        public string SecurityCode { get; set; } = string.Empty;
    }
}
