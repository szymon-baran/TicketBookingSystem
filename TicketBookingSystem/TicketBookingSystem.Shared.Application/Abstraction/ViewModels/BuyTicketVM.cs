using TicketBookingSystem.Shared.Dictionaries;

namespace TicketBookingSystem.Shared.Application
{
    public class BuyTicketVM
    {
        public string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; }
        public long OwnerPESEL { get; set; }
        public TicketType TicketType { get; set; } = TicketType.Normal;
        public bool IsSittingSpot { get; set; } = false;
    }
}
