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
        CreateMap<Pedido, PedidoTO>()
            .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.Cliente))
            .ForMember(dest => dest.ProdutosDoCarrinho, opt => opt.MapFrom(src => src.ProdutosDoCarrinho))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.ClienteId, opt => opt.MapFrom(src => src.ClienteId))
            .ForMember(dest => dest.ValorFrete, opt => opt.MapFrom(src => src.ValorFrete))
            .ForMember(dest => dest.QtdItens, opt =>opt.MapFrom(src => src.ProdutosDoCarrinho.Sum(a => a.Quantidade)))
            .ForMember(dest => dest.ValorTotal, opt => 
                opt.MapFrom(src => src.ProdutosDoCarrinho.Sum(a =>
                    a.Quantidade * a.Produto.PrecoUnitario)));
    }
}