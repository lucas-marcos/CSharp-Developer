using Back.Data;
using Back.Interface;
using Back.Interface.Repository;
using Back.Models;

namespace Back.Repositories;

public class PedidoRepository : Repository<Pedido>, IPedidoRepository 
{
    public PedidoRepository(ApplicationDbContext context) : base(context)
    {
    }
}