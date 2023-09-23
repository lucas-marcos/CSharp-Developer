namespace Back.Models;

public class ProdutosDoCarrinho : Entity
{
    public Produto Produto { get; private set; }
    public int ProdutoId { get; private set; }
    
    //EF Constructor
    protected ProdutosDoCarrinho()
    {
    }

    public ProdutosDoCarrinho(Produto produto, int produtoId)
    {
        Produto = produto;
        ProdutoId = produtoId;
    }
}