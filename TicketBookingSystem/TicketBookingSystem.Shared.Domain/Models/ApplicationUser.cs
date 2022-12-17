using Microsoft.AspNetCore.Identity;
using TicketBookingSystem.Shared.Dictionaries;

namespace TicketBookingSystem.Shared.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public int Age { get; set; }
        public MusicGenre FavouriteMusicGenre { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}