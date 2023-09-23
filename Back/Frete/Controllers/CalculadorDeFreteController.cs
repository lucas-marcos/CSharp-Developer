using Microsoft.AspNetCore.Mvc;

namespace Frete.Controllers;

[ApiController, Route("api/frete")]
public class CalculadorDeFreteController : ControllerBase
{
    [HttpGet, Route("calcular/qtd-itens/{qtdItens}")]
    public ActionResult<decimal> Calcular(int qtdItens)
    {
        return Ok(qtdItens.Calcular());
    }
}