using AutoMapper;
using Back.Interface.Services;
using Back.Models;
using Back.Models.DTO;
using Back.Models.TO;
using Microsoft.AspNetCore.Mvc;

namespace Back.Controller;

[ApiController, Route("api/pedido")]
public class PedidoController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IPedidoServices _pedidoServices;

    public PedidoController(IMapper mapper, IPedidoServices pedidoServices)
    {
        _mapper = mapper;
        _pedidoServices = pedidoServices;
    }

    [HttpPost]
    public ActionResult<PedidoTO> Post(PedidoDTO pedidoDto)
    {
        var pedido = _pedidoServices.Cadastrar(_mapper.Map<Pedido>(pedidoDto));

        return Ok(_mapper.Map<PedidoTO>(pedido));
    }
    
    [HttpGet]
    public ActionResult<List<PedidoTO>> Get()
    {
        var pedido = _pedidoServices.BuscarTodos();

        return Ok(_mapper.Map<List<PedidoTO>>(pedido));
    }
    
}
