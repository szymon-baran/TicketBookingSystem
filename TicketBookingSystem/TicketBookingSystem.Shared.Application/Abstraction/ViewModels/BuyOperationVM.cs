namespace TicketBookingSystem.Shared.Application
{
    public class BuyOperationVM
    {
        public int EventId { get; set; }
        public List<BuyTicketVM> Tickets { get; set; } = new();
    }
}
