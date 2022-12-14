using TicketBookingSystem.Shared.Dictionaries;

namespace TicketBookingSystem.Shared.Application
{
    public class ArtistAddEditVM
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
    }
}
