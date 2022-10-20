using TicketBookingSystem.Shared.Dictionaries;

namespace TicketBookingSystem.Shared.Domain
{
    public class Ticket
    {
        public int Id { get; set; }
        public TicketType TicketType { get; set; }
        public int EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}
