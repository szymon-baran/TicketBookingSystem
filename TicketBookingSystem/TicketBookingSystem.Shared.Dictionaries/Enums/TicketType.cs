using System.ComponentModel;
using System.Reflection;

namespace TicketBookingSystem.Shared.Dictionaries
{
    public enum TicketType
    {
        [Description("Normalny")]
        Normal = 0,
        [Description("Ulgowy")]
        Reduced = 1,
        [Description("Darmowy")]
        Free = 2
    }
}
