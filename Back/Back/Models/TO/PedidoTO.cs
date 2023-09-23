namespace Back.Models.TO;

public class PedidoTO
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; }
    public List<ProdutosDoCarrinhoTO> ProdutosDoCarrinho { get; set; }
    public decimal ValorFrete { get; set; }
    public decimal QtdItens { get; set; }
    public decimal ValorTotal { get; set; }
}