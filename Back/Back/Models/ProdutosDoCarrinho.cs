namespace Back.Models;

public class ProdutosDoCarrinho : Entity
{
    public Produto Produto { get; private set; }
    public int ProdutoId { get; private set; }
    public int Quantidade { get; private set; }

    //EF Constructor
    protected ProdutosDoCarrinho()
    {
    }

    public ProdutosDoCarrinho(Produto produto, int produtoId, int quantidade)
    {
        Produto = produto;
        ProdutoId = produtoId;
        Quantidade = quantidade;
    }
}