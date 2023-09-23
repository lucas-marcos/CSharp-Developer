using Back.Interface.Repository;
using Back.Interface.Services;
using Back.Models;

namespace Back.Services;

public class ClienteServices : IClienteServices
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteServices(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public void AdicionarSalvar(Cliente cliente) => _clienteRepository.AdicionarAtualizarSalvar(cliente);
    public void AdicionarSalvar(List<Cliente> clientes) => _clienteRepository.AdicionarAtualizarSalvar(clientes);
    public List<Cliente> BuscarTodos() => _clienteRepository.BuscarTodos().ToList();
    public void RemoverSalvar(List<Cliente> clientes) => _clienteRepository.RemoverSalvar(clientes);
}