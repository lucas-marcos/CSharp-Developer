using Back.Data;
using Back.Interface;
using Back.Interface.Repository;
using Back.Models;
using Microsoft.EntityFrameworkCore;

namespace Back.Repositories;

public class PedidoRepository : Repository<Pedido>, IPedidoRepository
{
    public PedidoRepository(ApplicationDbContext context) : base(context)
    {
    }

    public IQueryable<Pedido> BuscarTodos() => base.BuscarTodos()
        .Include(a => a.Cliente)
        .Include(a => a.ProdutosDoCarrinho)
        .ThenInclude(a => a.Produto);
}