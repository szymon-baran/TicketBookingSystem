namespace TicketBookingSystem.Shared.Application
{
    public class TicketPurchaseEventDetailsVM
    {
        public int? Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime EventTime { get; set; }
        public string PhotoUrl { get; set; } = "";
        public string ArtistNickName { get; set; }
        public string PlaceName { get; set; }
        public string PlaceCity { get; set; }
        public string PlaceCountry { get; set; }
        public int AvailableSittingTickets { get; set; }
        public int AvailableStandingTickets { get; set; }
        public int MaxSittingTicketsForPlace { get; set; }
        public int MaxStandingTicketsForPlace { get; set; }
        public double SittingTicketPrice { get; set; }
        public double StandingTicketPrice { get; set; }
        public double ReducedDiscount { get; set; }
    }
}