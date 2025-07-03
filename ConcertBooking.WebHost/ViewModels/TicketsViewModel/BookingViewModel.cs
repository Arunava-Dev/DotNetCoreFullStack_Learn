namespace ConcertBooking.WebHost.ViewModels.TicketsViewModel
{
    public class BookingViewModel
    {
        public int BookingId { get; set; }
        public DateTime BookingDate { get; set; }
        public string ConcertName { get; set; }
        public List<TicketsViewModel> Tickets { get; set; }
    }
}
