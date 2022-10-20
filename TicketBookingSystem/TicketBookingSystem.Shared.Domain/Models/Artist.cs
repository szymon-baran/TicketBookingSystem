using Duende.IdentityServer.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Shared.Dictionaries;

namespace TicketBookingSystem.Shared.Domain
{
    public class Artist
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string NickName { get; set; } = "";
        public string Description { get; set; } = "";
        public string PhotoUrl { get; set; } = "";
        public string SpotifyUrl { get; set; } = "";
        public MusicGenre PrimaryMusicGenre { get; set; }
        public MusicGenre? SecondaryMusicGenre { get; set; }
        public float AverageFanbaseAge { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}
