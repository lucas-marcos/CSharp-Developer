using Back.Interface.Repository;
using Back.Interface.Services;
using Back.Models;

namespace Back.Services;

public class PedidoServices : IPedidoServices
{
    private readonly IPedidoRepository _pedidoRepository;

    public PedidoServices(IPedidoRepository pedidoRepository)
    {
        _pedidoRepository = pedidoRepository;
    }

    public List<Pedido> BuscarTodos() => _pedidoRepository.BuscarTodos().ToList();
    public void RemoverSalvar(List<Pedido> pedidos) => _pedidoRepository.RemoverSalvar(pedidos);

    public void Cadastrar(Pedido pedido)
    {
        _pedidoRepository.AdicionarAtualizarSalvar(pedido);

    }
}