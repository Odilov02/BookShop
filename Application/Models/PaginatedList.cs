namespace Application.Models
{
    public class PaginatedList<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPage { get; private set; }

        public bool HasPreviousPage => PageIndex > 0;
        public bool HasNextPage => PageIndex < TotalPage;

        public List<T> items { get; private set; } = new List<T>();
        public PaginatedList(List<T> Items, int Count, int PageSize, int PageIndex)
        {
            TotalPage = (int)Math.Ceiling(Count / (double)PageSize);
            this.PageIndex = PageIndex;
            this.items = Items;
        }

        public static PaginatedList<T> CreateAsync(List<T> collection, int pageSize, int pageIndex)
        {
            int count = collection.Count;
            List<T> items = collection.Skip(pageSize - 1).Take(pageSize).ToList();

            return new PaginatedList<T>(items, count, pageSize, pageIndex);
        }
    }
}
