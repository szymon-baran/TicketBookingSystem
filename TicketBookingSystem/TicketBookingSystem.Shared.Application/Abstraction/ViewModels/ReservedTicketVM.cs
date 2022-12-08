using TicketBookingSystem.Shared.Dictionaries;

namespace TicketBookingSystem.Shared.Application
{
    public class ReservedTicketVM
    {
        public int Id { get; set; }
        public string TicketTypeName { get; set; }
        public string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; }
        public bool IsSittingSpot { get; set; }
        public string EventName { get; set; }
        public DateTime EventTime { get; set; }
    }
}
