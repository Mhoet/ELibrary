namespace ELibrary.API.Services.PaginationService.Implementation
{
    public class PageFilter
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public PageFilter(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize > 10 ? 10 : pageSize;
        }
    }
}