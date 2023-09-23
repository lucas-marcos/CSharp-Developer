using Back.Interface.Repository;
using Back.Interface.Services;
using Back.Models;

namespace Back.Services;

public class ProdutoServices : IProdutoServices
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoServices(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public List<Produto> BuscarTodos() => _produtoRepository.BuscarTodos().ToList();
    public void AdicionarSalvar(List<Produto> produtos) => _produtoRepository.AdicionarAtualizarSalvar(produtos);
    public void RemoverSalvar(List<Produto> produtos) => _produtoRepository.RemoverSalvar(produtos);
}