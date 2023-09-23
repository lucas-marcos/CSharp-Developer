using Back.Models;

namespace Back.Interface.Services;

public interface IPedidoServices : IScoped
{
    Pedido Cadastrar(Pedido pedido);
    List<Pedido> BuscarTodos();
}