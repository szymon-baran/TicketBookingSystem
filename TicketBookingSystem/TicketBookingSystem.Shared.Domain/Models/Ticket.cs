using TicketBookingSystem.Shared.Dictionaries;

namespace TicketBookingSystem.Shared.Domain
{
    public class Ticket
    {
        public int Id { get; set; }
        public TicketType TicketType { get; set; }
        public string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; }
        public long OwnerPESEL { get; set; }
        public bool IsSittingSpot { get; set; }
        public int EventId { get; set; }
        public virtual Event Event { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
