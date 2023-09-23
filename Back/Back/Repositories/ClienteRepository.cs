using Back.Data;
using Back.Interface.Repository;
using Back.Models;

namespace Back.Repositories;

public class ClienteRepository : Repository<Cliente>, IClienteRepository
{
    public ClienteRepository(ApplicationDbContext context) : base(context)
    {
    }
}