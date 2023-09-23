namespace Back.Models;

public class Pedido : Entity
{
    public Cliente Cliente { get; private set; }
    public int ClienteId { get; private set; }
    public List<ProdutosDoCarrinho> ProdutosDoCarrinho { get; private set; }
    public decimal ValorFrete { get; private set; }

    //EF Constructor
    protected Pedido()
    {
        
    }
    
    public Pedido(int id, int clienteId, decimal valorFrete)
    {
        Id = id;
        ClienteId = clienteId;
        ValorFrete = valorFrete;
    }
}