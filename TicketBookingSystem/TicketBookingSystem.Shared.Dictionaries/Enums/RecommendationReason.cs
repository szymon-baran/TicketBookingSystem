using System.ComponentModel;
using System.Reflection;

namespace TicketBookingSystem.Shared.Dictionaries
{
    public enum RecommendationReason
    {
        [Description("Brak")]
        None = 0,
        [Description("Ulubiony gatunek muzyczny")]
        FavouriteMusicGenre = 1,
        [Description("Wiek")]
        Age = 2,
        [Description("Lokalizacja")]
        Location = 3,
        [Description("Ostatnio zakupiony gatunek biletu")]
        PreviouslyPurchasedTicketGenre = 4
    }
}
