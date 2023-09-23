using AutoMapper;
using Back.Models;
using Back.Models.DTO;
using Back.Models.TO;

namespace Back.Framework;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ClienteTO, Cliente>();
        CreateMap<Cliente, ClienteTO>();
        
        CreateMap<ProdutoTO, Produto>();
        CreateMap<Produto, ProdutoTO>();

        CreateMap<PedidoDTO, Pedido>();
        CreateMap<Pedido, PedidoTO>();

    }
}