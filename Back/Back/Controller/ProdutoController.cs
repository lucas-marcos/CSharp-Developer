using AutoMapper;
using Back.Interface.Services;
using Back.Models.TO;
using Microsoft.AspNetCore.Mvc;

namespace Back.Controller;

[ApiController, Route("api/produto")]
public class ProdutoController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IProdutoServices _produtoServices;

    public ProdutoController(IMapper mapper, IProdutoServices produtoServices)
    {
        _mapper = mapper;
        _produtoServices = produtoServices;
    }

    [HttpGet]
    public ActionResult<List<ProdutoTO>> Get()
    {
        var produtos = _produtoServices.BuscarTodos();

        return Ok(_mapper.Map<List<ProdutoTO>>(produtos));
    }
}