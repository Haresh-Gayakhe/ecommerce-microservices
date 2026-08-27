namespace ECommerce.Application.Common.Models
{
    public class ProductQueryParameters
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? Search { get; set; }
        public Guid? CategoryId { get; set; }
        public string? SortBy { get; set; }
    }
}
