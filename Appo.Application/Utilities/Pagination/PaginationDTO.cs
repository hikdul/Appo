namespace Appo.Application.Utilities.Pagination
{
    public class PaginationDTO<T>
    {
		public List<T> Elements { get; set; }
		public int totalElements { get; set; }
    }
}
