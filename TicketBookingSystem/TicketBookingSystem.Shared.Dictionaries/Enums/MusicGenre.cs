using System.ComponentModel;
using System.Reflection;

namespace TicketBookingSystem.Shared.Dictionaries
{
    public enum MusicGenre
    {
        [Description("Brak")]
        None = 0,
        [Description("Klasyczna")]
        Classical = 1,
        [Description("Disco polo")]
        DiscoPolo = 2,
        [Description("Elektroniczna")]
        Electronic = 3,
        [Description("Hip-hop")]
        HipHop = 4,
        [Description("Jazz")]
        Jazz = 5,
        [Description("Metal")]
        Metal = 6,
        [Description("Pop")]
        Pop = 7,
        [Description("Rock")]
        Rock = 8,
        [Description("R&B")]
        RandB = 9
    }
}
