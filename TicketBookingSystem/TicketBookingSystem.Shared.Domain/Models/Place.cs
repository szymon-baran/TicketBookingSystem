using Microsoft.AspNetCore.Identity;
using System.Reflection.Metadata;

namespace TicketBookingSystem.Shared.Domain
{
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string City { get; set; } = "";
        public string Country { get; set; } = "";
        public string PhotoUrl { get; set; } = "";
        public virtual ICollection<Event> Events { get; set; }
    }
}