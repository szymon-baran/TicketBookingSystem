namespace TicketBookingSystem.Shared
{
    public class PaginationParameters
    {
        public int PageNumber { get; set; } = 1;
        private int currentPageSize = 8;
        public int PageSize
        {
            get => currentPageSize;
            set => currentPageSize = value;
        }
    }
}
