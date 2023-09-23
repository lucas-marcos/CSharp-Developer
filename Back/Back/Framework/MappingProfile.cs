using AutoMapper;
using Back.Models;
using Back.Models.TO;

namespace Back.Framework;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ClienteTO, Cliente>();
        CreateMap<Cliente, ClienteTO>();
    }
}