using Back.Models;

namespace Back.Interface.Services;

public interface IPedidoServices : IScoped
{
    void Cadastrar(Pedido pedido);
    List<Pedido> BuscarTodos();
    void RemoverSalvar(List<Pedido> pedidos);
}