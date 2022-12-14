namespace TicketBookingSystem.Shared.Application
{
    public class EventAddEditVM
    {
        public int? Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public DateTime EventTime { get; set; }
        public string PhotoUrl { get; set; } = "";
        public int ArtistId { get; set; }
        public int PlaceId { get; set; }
        public int AvailableSittingTickets { get; set; }
        public int AvailableStandingTickets { get; set; }
        public double SittingTicketPrice { get; set; }
        public double StandingTicketPrice { get; set; }
        public double ReducedDiscount { get; set; } = 0.5;
    }
}