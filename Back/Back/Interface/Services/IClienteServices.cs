using Back.Models;

namespace Back.Interface.Services;

public interface IClienteServices : IScoped
{
    void AdicionarSalvar(Cliente cliente);
    List<Cliente> BuscarTodos();
    void RemoverSalvar(List<Cliente> clientes);
    void AdicionarSalvar(List<Cliente> clientes);
}