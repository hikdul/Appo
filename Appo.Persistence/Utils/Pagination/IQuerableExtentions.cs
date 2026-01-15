namespace Appo.Persistence.Utils.Pagination
{
    public static class IQuerableExtentions
    {
		public static IQueryable<T> Pagination<T>(this IQueryable<T> queryable, int currentPage, int  maxRegisterPerPage)
		{
			return queryable
				.Skip((currentPage -1) * maxRegisterPerPage)
				.Take(maxRegisterPerPage);
		}
    }
}
