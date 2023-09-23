using Back.Framework;
using Back.Interface.Services;
using Back.Models;

namespace Back.Services;

public class SetupServices : ISetupServices
{
    private readonly IClienteServices _clienteServices;
    private readonly IConsultadorServices _consultadorServices;

    public SetupServices(IClienteServices clienteServices, IConsultadorServices consultadorServices)
    {
        _clienteServices = clienteServices;
        _consultadorServices = consultadorServices;
    }

    public void Setup()
    {
        AtualizarBaseClientes();
    }

    private void AtualizarBaseClientes()
    {
        RemoverClientes();
        SalvarDadosClientes();
    }

    private void SalvarDadosClientes()
    {
        var clientes = ConsultarCLientesApi();
        _clienteServices.AdicionarSalvar(clientes);
    }

    private List<Cliente> ConsultarCLientesApi()
    {
        var clientesJson = _consultadorServices.RetornarDadosRequest("https://private-anon-f30d07d849-maximatech.apiary-mock.com/fullstack/cliente");

        return clientesJson.FromJsonIgnoreId<List<Cliente>>();
    }

    private void RemoverClientes()
    {
        var clientes = _clienteServices.BuscarTodos();
        _clienteServices.RemoverSalvar(clientes);
    }
}