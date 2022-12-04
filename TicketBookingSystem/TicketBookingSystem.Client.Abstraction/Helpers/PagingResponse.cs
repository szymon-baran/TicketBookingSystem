using TicketBookingSystem.Shared;

namespace TicketBookingSystem.Client.Abstraction.Helpers
{
    public class PagingResponse<T> where T : class
    {
        public List<T> Items { get; set; }
        public PaginationMetaData MetaData { get; set; }
    }
}
