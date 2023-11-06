using Microsoft.EntityFrameworkCore;

namespace ProyectoBaseNetCore.Utilidades
{
    public static class HttpContextExtentions
    {
        public static async Task InsertarParametrosPaginacionEnCabecera<T>(this HttpContext httpContext, IQueryable<T> queryable)
        {
            if (httpContext is null) { throw new ArgumentNullException(nameof(httpContext)); }

            double cantidad = await queryable.CountAsync();
            httpContext.Response.Headers.Add("cantidadTotalRegistros", cantidad.ToString());
        }
    }
}