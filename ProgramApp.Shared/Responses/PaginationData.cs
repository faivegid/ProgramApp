namespace ProgramApp.Shared.Responses
{
    public class PaginationData<T> 
    {
        public IEnumerable<T> Data { get; set; } = new List<T>();
        public int TotalCount { get; set; }
        public int Page { get; set; }

        public PaginationData(int page, int totalCount, IEnumerable<T> data)
        {
            Page = page;
            TotalCount = totalCount;
            Data = data;
        }
    }
}
