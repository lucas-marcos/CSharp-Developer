using Back.Framework;
using Back.Interface.Services;
using Back.Models;

namespace Back.Services;

public class SetupServices : ISetupServices
{
    private readonly IClienteServices _clienteServices;
    private readonly IConsultadorServices _consultadorServices;
    private readonly IProdutoServices _produtoServices;

    public SetupServices(IClienteServices clienteServices, IConsultadorServices consultadorServices, IProdutoServices produtoServices)
    {
        _clienteServices = clienteServices;
        _consultadorServices = consultadorServices;
        _produtoServices = produtoServices;
    }

    public void Setup()
    {
        AtualizarBaseClientes();
        AtualizarBaseProdutos();
    }

    private void AtualizarBaseProdutos()
    {
        RemoverProdutos();
        SalvarDadosProdutos();
    }

    private void SalvarDadosProdutos()
    {
        var produtos = ConsultarProdutosApi();
        _produtoServices.AdicionarSalvar(produtos);
    }

    private List<Produto> ConsultarProdutosApi()
    {
        var produtosJson = _consultadorServices.RetornarDadosRequest("https://private-anon-f30d07d849-maximatech.apiary-mock.com/fullstack/produto");

        return produtosJson.FromJsonIgnoreId<List<Produto>>();
    }

    private void RemoverProdutos()
    {
        var produtosParaRemover = _produtoServices.BuscarTodos();
        _produtoServices.RemoverSalvar(produtosParaRemover);
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