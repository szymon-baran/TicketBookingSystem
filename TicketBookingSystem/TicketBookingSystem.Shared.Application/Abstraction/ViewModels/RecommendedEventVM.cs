using TicketBookingSystem.Shared.Dictionaries;

namespace TicketBookingSystem.Shared.Application
{
    public class RecommendedEventVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public RecommendationReason RecommendationReason { get; set; }
    }
}