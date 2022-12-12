namespace TicketBookingSystem.Shared.Domain
{
    public class TicketPurchasePlaceDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int MaxSittingCapacity { get; set; }
        public int MaxStandingCapacity { get; set; }
    }
}