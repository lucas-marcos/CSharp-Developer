using Back.Framework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Back.Controller.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is MaximaTechException)
            context.Result = new ObjectResult("Não foi possível realizar a operação pelo seguinte motivo: " + context.Exception.Message)
            {
                StatusCode = 400 // Código de status de erro do cliente
            };
        else if (context.Exception is Exception)
            context.Result = new ObjectResult("Ocorreu o seguinte erro durante a operação: " + context.Exception.Message)
            {
                StatusCode = 500 // Código de status de erro interno do servidor
            };

        // Marcar a exceção como tratada para evitar que outros manipuladores de exceção sejam acionados
        context.ExceptionHandled = true;
    }
}