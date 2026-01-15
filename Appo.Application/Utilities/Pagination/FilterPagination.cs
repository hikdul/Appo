namespace Appo.Application.Utilities.Pagination
{
    public class FilterPagination
    {
		///	<summary>
		/// indica la pagina actual
		/// </sumary>
		public int CurrentPage { get; set; }
		///	<summary>
		/// indica la cantidad de elementos a mostrar
		/// </sumary>
		public int MaxRegisterPerPage { get; set; }
    }
}
