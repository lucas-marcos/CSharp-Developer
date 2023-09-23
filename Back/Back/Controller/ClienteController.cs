using AutoMapper;
using Back.Interface.Services;
using Back.Models;
using Back.Models.TO;
using Microsoft.AspNetCore.Mvc;

namespace Back.Controller;

[ApiController, Route("api/cliente")]
public class ClienteController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IClienteServices _clienteServices;

    public ClienteController(IMapper mapper, IClienteServices clienteServices)
    {
        _mapper = mapper;
        _clienteServices = clienteServices;
    }

    [HttpGet]
    public ActionResult<List<ClienteTO>> Get()
    {
        var clientes = _clienteServices.BuscarTodos();

        return Ok(_mapper.Map<List<ClienteTO>>(clientes));
    }
}