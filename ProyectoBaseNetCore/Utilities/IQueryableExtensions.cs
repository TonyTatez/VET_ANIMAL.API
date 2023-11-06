using ProyectoBaseNetCore.DTOs;

namespace ProyectoBaseNetCore.Utilidades
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Paginar<T>(this IQueryable<T> queryable, PaginacionDTO paginacionDTO)
        {
            return queryable.Skip((paginacionDTO.Pagina - 1) * paginacionDTO.DatosPorPagina).Take(paginacionDTO.DatosPorPagina);
        }
    }
}