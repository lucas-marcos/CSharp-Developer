using Back.Models;

namespace Back.Interface.Repository;

public interface IProdutoRepository : IRepository<Produto>, IScoped
{
    
}