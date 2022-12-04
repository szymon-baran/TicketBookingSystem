namespace TicketBookingSystem.Shared
{
    public class PagedList<T> : List<T>
    {
        public PaginationMetaData MetaData { get; set; }

        public PagedList(IEnumerable<T> items, int count, int pageNumber, int pageSize)
        {
            MetaData = new()
            {
                TotalCount = count,
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize)
            };

            AddRange(items);
        }

        public static PagedList<T> ToPagedList(IEnumerable<T> sourceData, int pageNumber, int pageSize)
        {
            var count = sourceData.Count();
            var items = sourceData
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToList();

            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}