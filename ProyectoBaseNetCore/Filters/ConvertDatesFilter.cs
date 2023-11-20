using Microsoft.AspNetCore.Mvc.Filters;
using System;
namespace VET_ANIMAL_API.Filters
{
    public class ConvertDatesFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            foreach (var parameter in context.ActionDescriptor.Parameters)
            {
                if (context.ActionArguments.TryGetValue(parameter.Name, out var argumentValue))
                {
                    if (argumentValue is DateTime dateTime)
                    {
                        // Convierte el DateTime a UTC antes de que llegue al controlador
                        DateTime utcDateTime = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);

                        // Actualiza el valor del parámetro
                        context.ActionArguments[parameter.Name] = utcDateTime;
                    }
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Este método se ejecuta después de que se ha completado la ejecución de la acción.
        }
    }
}
