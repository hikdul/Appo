namespace Appo.API.Utilities.Pagination
{
    public static class HttpContextExtentions
    {
		public static void InsertPaginationOnHead(this HttpContext httpContext, int TotalReg)
		{
			httpContext.Response.Headers.Append("total-reg", TotalReg.ToString());
		}
    }
}
