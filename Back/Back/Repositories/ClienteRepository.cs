using Back.Data;
using Back.Models;
using Back.Repositories.Interface;

namespace Back.Repositories;

public class ClienteRepository : Repository<Cliente>, IClienteRepository
{
    public ClienteRepository(ApplicationDbContext context) : base(context)
    {
    }
}