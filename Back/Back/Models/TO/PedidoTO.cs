namespace Back.Models.TO;

public class PedidoTO
{
    public int ClienteId { get; set; }
    public List<ProdutosDoCarrinho> ProdutosDoCarrinho { get; set; }
    public decimal ValorFrete { get; set; }
}