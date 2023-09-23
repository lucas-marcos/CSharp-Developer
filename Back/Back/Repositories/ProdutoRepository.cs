using Back.Data;
using Back.Interface.Repository;
using Back.Models;

namespace Back.Repositories;

public class ProdutoRepository : Repository<Produto>, IProdutoRepository
{
    public ProdutoRepository(ApplicationDbContext context) : base(context)
    {
    }
}