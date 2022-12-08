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

    public static class TicketTypeExtensions
    {
        public static string GetDescription(this TicketType ticketType)
        {
            Type type = ticketType.GetType();
            string name = Enum.GetName(type, ticketType);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    DescriptionAttribute attr =
                           Attribute.GetCustomAttribute(field,
                             typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return null;

        }
    }
}
