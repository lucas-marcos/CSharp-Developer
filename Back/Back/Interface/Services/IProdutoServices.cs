using Back.Models;

namespace Back.Interface.Services;

public interface IProdutoServices : IScoped
{
    List<Produto> BuscarTodos();
    void AdicionarSalvar(List<Produto> produtos);
    void RemoverSalvar(List<Produto> produtos);
}